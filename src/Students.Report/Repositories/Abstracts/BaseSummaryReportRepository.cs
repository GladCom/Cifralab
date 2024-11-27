using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Filters.Filters;

namespace Students.Reports.Repositories.Abstracts;

/// <summary>
///   Репозиторий сводного отчета.
/// </summary>
public abstract class BaseSummaryReportRepository<TEntity> : BaseReportRepository<TEntity> where TEntity : class
{
  /// <summary>
  ///   Формирование данных для отчета.
  /// </summary>
  /// <param name="filter">Фильтр</param>
  /// <param name="condition">Условие.</param>
  /// <returns>Данные.</returns>
  public async Task<List<TEntity>> Get(GroupFilter filter, Func<Group, bool> condition)
  {
    var filterPredicate = filter.GetFilterPredicate();
    return await this.FetchData(group =>
      filterPredicate(group) && condition(group));
  }

  /// <summary>
  ///   Извлечение данных.
  /// </summary>
  /// <returns>Список данных отчета.</returns>
  protected override async Task<List<TEntity>> FetchData(Predicate<Group> condition)
  {
    var listSummaryModel = new List<TEntity>();
    await foreach(var group in this.Context.Groups
                   .Include(group => group.EducationProgram)
                   .Include(group => group.Students)
                   .Include(group => group.GroupStudent)
                      .ThenInclude(groupStudent => groupStudent.Request)
                        .ThenInclude(request => request!.Status)
                   .Include(group => group.GroupStudent)
                      .ThenInclude(groupStudent => groupStudent.Request)
                        .ThenInclude(request => request!.DocumentRiseQualification)
                          .ThenInclude(drq => drq!.KindDocumentRiseQualification)
                   .AsNoTracking()
                   .AsAsyncEnumerable())
      if(condition(group))
        listSummaryModel.Add(this.InitializeObject(group));
    return listSummaryModel;
  }

  /// <summary>
  ///   Инициализация свойств объекта.
  /// </summary>
  /// <param name="group">Группа.</param>
  /// <returns>Сущность.</returns>
  protected abstract TEntity InitializeObject(Group group);

  public BaseSummaryReportRepository(StudentContext context) : base(context) { }
}