using System;
using System.Collections.Generic;

namespace Students.Models.Searches.Searches
{
  /// <summary>
  /// Поиск по сущности.
  /// </summary>
  /// <typeparam name="TEntity">Сущность, по которой выполняется поиск.</typeparam>
  public abstract class Search<TEntity> where TEntity : class
  {
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Текст поискового запроса.
    /// </summary>
    public string? Query { get; set; }

    /// <summary>
    /// Список свойств, по которым выполняется поиск.
    /// </summary>
    public List<string> SearchProperties { get; set; } = new();

    /// <summary>
    /// Возвращает предикат для фильтрации сущностей согласно условиям поиска.
    /// </summary>
    /// <returns>Предикат поиска.</returns>
    public abstract Predicate<TEntity> GetSearchPredicate();
  }
}
