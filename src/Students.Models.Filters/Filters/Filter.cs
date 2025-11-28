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
  
  /// <summary>
  /// Получить фильтр по текстовому свойству.
  /// </summary>
  /// <param name="filterValue">Значение свойства фильтра.</param>
  /// <param name="modelValue">Значение свойства модели.</param>
  /// <returns></returns>
  protected static bool FilterByStringProperty(string? filterValue, string modelValue)
  {
    return string.IsNullOrEmpty(filterValue) || 
           modelValue.ToLower().Contains(filterValue.ToLower());
  }
}