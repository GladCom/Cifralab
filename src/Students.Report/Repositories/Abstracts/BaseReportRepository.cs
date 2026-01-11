using Students.DBCore.Contexts;
using Students.Models;

namespace Students.Reports.Repositories.Abstracts;

/// <summary>
///   Базовый репозиторий отчета.
/// </summary>
/// <typeparam name="TEntity">Сущность.</typeparam>
public abstract class BaseReportRepository<TEntity> where TEntity : class
{
  protected readonly StudentContext Context;

  /// <summary>
  ///   Извлечение данных.
  /// </summary>
  /// <param name="condition">Условие.</param>
  /// <returns>Список сущностей.</returns>
  protected abstract Task<List<TEntity>> FetchData(Predicate<Group> condition);

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  protected BaseReportRepository(StudentContext context)
  {
    this.Context = context;
  }
}