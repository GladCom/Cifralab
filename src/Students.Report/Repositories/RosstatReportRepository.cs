using Microsoft.EntityFrameworkCore;
using MoreLinq;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using Students.Models.Filters.Filters;
using Students.Reports.Models;
using Students.Reports.Repositories.Abstracts;

namespace Students.Reports.Repositories;

/// <summary>
///   Репозиторий отчета Росстат.
/// </summary>
public class RosstatReportRepository : BaseReportRepository<RosstatModel>
{
    /// <summary>
    ///   Формирование данных для отчета.
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <returns>Данные.</returns>
    public async Task<List<RosstatModel>> Get(GroupFilter filter)
    {
        return await this.FetchData(filter.GetFilterPredicate());
    }

    /// <summary>
    ///   Извлечение данных.
    /// </summary>
    /// <param name="condition">Условие</param>
    /// <returns>Список данных отчета.</returns>
    protected override async Task<List<RosstatModel>> FetchData(Predicate<Group> condition)
    {
        var rosstatModels = new List<RosstatModel>();
        await foreach (var group in this.Context.Groups
                           .Include(group => group.Students)
                           .ThenInclude(student => student.TypeEducation)
                           .Include(group => group.Students)
                           .ThenInclude(student => student.Requests)
                           .ThenInclude(req => req.StudentStatus)
                           .Include(group => group.Students)
                           .ThenInclude(student => student.ScopeOfActivityLevelOne)
                           .Include(group => group.Students)
                           .ThenInclude(student => student.ScopeOfActivityLevelTwo)
                           .Include(group => group.EducationProgram)
                           .ThenInclude(ep => ep.KindDocumentRiseQualification)
                           .Include(group => group.EducationProgram)
                           .ThenInclude(ep => ep.EducationForm)
                           .Include(group => group.EducationProgram)
                           .ThenInclude(ep => ep.FinancingType)
                           .AsNoTracking()
                           .AsAsyncEnumerable())
            if (condition(group))
            {
                // декартово произведение студентов и их заявок
                rosstatModels.AddRange(
                    group.Students.SelectMany(
                        student => student.Requests ?? Enumerable.Empty<Request>(),
                        (student, req) => InitializeObject(student, group, req)
                    )
                );
            }

        return rosstatModels;
    }


    /// <summary>
    ///   Инициализация свойств оъекта.
    /// </summary>
    /// <param name="student">Сущность.</param>
    /// <param name="group">Сущность.</param>
    /// <returns>Сущность.</returns>
    private static RosstatModel InitializeObject(Student student, Group group, Request request)
    {
        var empty = string.Empty;
        return new RosstatModel
        {
            FullName = $"{student.Family} {student.Name} {student.Patron}".Trim(),
            Status = request.StudentStatus?.Name,
            BirthDate = student.BirthDate.ToString("dd.MM.yyyy"),
            Age = student.Age.ToString(),
            Gender = student.Sex == SexHuman.Woman ? "Жен" : "Муж",
            EducationLevel = student.TypeEducation?.Name ?? empty,
            Citizenship = student.Nationality,
            ProgramName = group.EducationProgram?.Name ?? empty,
            HoursCount = group.EducationProgram?.HoursCount.ToString() ?? "0",
            StartDate = group.StartDate.ToString("dd.MM.yyyy"),
            EndDate = group.EndDate.ToString("dd.MM.yyyy"),
            StudyForm = group.EducationProgram?.EducationForm?.Name ?? empty,
            FundingSource = group.EducationProgram?.FinancingType?.SourceName ?? empty,
            GroupName = group.Name ?? empty,
            DocumentType = group.EducationProgram?.KindDocumentRiseQualification?.Name ?? empty,
            IsNetworkForm =
                group.EducationProgram is not null && group.EducationProgram.IsNetworkProgram ? "Да" : "Нет",
            UseELearning = group.EducationProgram is not null && group.EducationProgram.IsNetworkProgram ? "Да" : "Нет",
            UseDistanceTech = group.EducationProgram is not null && group.EducationProgram.IsDOTProgram ? "Да" : "Нет",
            UseFullDistanceTech =
                group.EducationProgram is not null && group.EducationProgram.IsDOTProgram ? "Да" : "Нет",
            HasDisability = student.Disability is not null && student.Disability.Value ? "Да" : "Нет",
            IsModularProgram = group.EducationProgram is not null && group.EducationProgram.IsModularProgram
                ? "Да"
                : "Нет",
            ScopeOfActivityLevel1 = student.ScopeOfActivityLevelOne.NameOfScope,
            ScopeOfActivityLevel2 = student.ScopeOfActivityLevelTwo.NameOfScope
        };
    }


    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="context">Контекст.</param>
    public RosstatReportRepository(StudentContext context) : base(context)
    {
    }
}