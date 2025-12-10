using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
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
  /// Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected override async Task<List<RosstatModel>> FetchData(Predicate<Group> condition)
  {
    throw new NotImplementedException();
  }
  
  /// <summary>
  /// Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected async Task<RosstatModel> FetchModel(Predicate<Group> condition)
  {
    var rosstatModel = new RosstatModel();
    var programs = this.Context.Groups.Where(g => condition(g))
      .Include(p=>p.EducationProgram)
        .ThenInclude(ep => ep.KindEducationProgram)
      .ToList();
    rosstatModel.AdvancedTrainingProgramsCount = programs
      .Count(p => p.EducationProgram?.KindEducationProgram?.Name == "Программа повышения квалификации");
    rosstatModel.ProfessionalRetrainingProgramsCount = programs
      .Count(p => p.EducationProgram?.KindEducationProgram?.Name == "Программа профессиональной переподготовки");
    return rosstatModel;
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public RosstatReportRepository(StudentContext context) : base(context) { }
}