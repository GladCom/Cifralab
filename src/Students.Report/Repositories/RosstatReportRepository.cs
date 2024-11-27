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
  ///   Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие</param>
  /// <returns>Список данных отчета.</returns>
  protected override async Task<List<RosstatModel>> FetchData(Predicate<Group> condition)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public RosstatReportRepository(StudentContext context) : base(context) { }
}