namespace Students.Models.Filters.Filters;

/// <summary>
/// Фильтр.
/// </summary>
/// <typeparam name="TEntity">Сущность подвергаемая фильтрации.</typeparam>
public abstract class Filter<TEntity> where TEntity : class
{
  /// <summary>
  /// Id сущности.
  /// </summary>
  public Guid? Id { get; set; }

  /// <summary>
  /// Предикат по которому осуществляется фильтрация.
  /// </summary>
  /// <returns>Предикат.</returns>
  public abstract Predicate<TEntity> GetFilterPredicate();
}