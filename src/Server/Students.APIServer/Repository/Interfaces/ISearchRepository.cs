using Students.Models.Searches.Searches;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Контракт репозитория для выполнения поисковых запросов
/// по заданной сущности с возвратом DTO.
/// </summary>
/// <typeparam name="TEntity">
/// Тип сущности, по которой выполняется поиск.
/// </typeparam>
/// <typeparam name="TResult">
/// Тип возвращаемого DTO.
/// </typeparam>
public interface ISearchRepository<TEntity, TResult> where TEntity : class where TResult : class
{
  /// <summary>
  /// Выполняет поиск данных по параметрам,
  /// заданным в типизированной модели поиска.
  /// </summary>
  /// <param name="search">
  /// Типизированная модель поиска.
  /// </param>
  /// <returns>
  /// Коллекция DTO, соответствующих параметрам поиска.
  /// </returns>
  Task<IEnumerable<TResult>> SearchData(Search<TEntity> search);
}