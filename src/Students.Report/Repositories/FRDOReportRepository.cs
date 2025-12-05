using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using Students.Models.Filters.Filters;
using Students.Reports.Models;
using Students.Reports.Repositories.Abstracts;

namespace Students.Reports.Repositories;

/// <summary>
///   Репозиторий отчета ПФДО.
/// </summary>
public class FRDOReportRepository : BaseReportRepository<FRDOModel>
{
  /// <summary>
  ///   Формирование данных для отчета.
  /// </summary>
  /// <param name="filter">Фильтр</param>
  /// <returns>Данные.</returns>
  public async Task<List<FRDOModel>> Get(GroupFilter filter)
  {
    return await this.FetchData(filter.GetFilterPredicate());
  }

  /// <summary>
  ///   Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected override async Task<List<FRDOModel>> FetchData(Predicate<Group> condition)
  {
    var frdoModels = new List<FRDOModel>();
    await foreach(var group in this.Context.Groups
      .Include(group => group.Students)
        .ThenInclude(student => student.TypeEducation)
      .Include(group => group.EducationProgram)
        .ThenInclude(ep => ep!.FEAProgram)
      .Include(group => group.EducationProgram)
        .ThenInclude(ep => ep!.EducationForm)
      .Include(group => group.EducationProgram)
        .ThenInclude(ep => ep!.FinancingType)
      .Include(group => group.EducationProgram)
        .ThenInclude(ep => ep!.KindDocumentRiseQualification)
      .AsNoTracking()
      .AsAsyncEnumerable())
      if(condition(group))
      {
        frdoModels.AddRange(group.Students.Select(student => InitializeObject(student, group)));
      }

    return frdoModels;
  }

  /// <summary>
  ///   Инициализация свойств оъекта.
  /// </summary>
  /// <param name="student">Сущность.</param>
  /// <param name="group">Сущность.</param>
  /// <returns>Сущность.</returns>
  private static FRDOModel InitializeObject(Student student, Group group)
  {
    var empty = string.Empty;
    return new FRDOModel
    {
      TypeDocument = group.EducationProgram!.KindDocumentRiseQualification!.Name,
      SeriesDocuments = empty,
      DocumentNumber = empty,
      DateOfIssueDocument = empty,
      RegistrationNumber = empty,
      AdditionalProfessionalProgram = empty,
      NameAdditionalProfessionalProgram = group.EducationProgram!.Name,
      NameQualification = group.EducationProgram!.FEAProgram!?.Name ?? empty,
      LevelEducationHE = student.TypeEducation!.Name,
      SurnameIndicatedHE = student.Family,
      SeriesHE = student.DocumentSeries,
      NumberHE = student.DocumentNumber,
      YearBeginningTraining = group.StartDate.ToString(),
      YearGraduation = group.EndDate.ToString(),
      DurationTraining = group.EducationProgram!.HoursCount.ToString(),
      RecipientLastName = student.Family,
      RecipientName = student.Name,
      RecipientPatronymic = student.Patron,
      RecipientDateBirth = student.BirthDate.ToString(),
      RecipientGender = student.Sex == SexHuman.Woman ? "Жен." : "Муж.",
      RecipientSNILS = student.SNILS,
      FormEducation = group.EducationProgram.EducationForm!.Name,
      SourceFundingForTraining = group.EducationProgram.FinancingType!.SourceName
    };
  }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public FRDOReportRepository(StudentContext context) : base(context) { }
}