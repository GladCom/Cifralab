namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс generic репозитория
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IGenericRepository<TEntity> where TEntity : class
{
  /// <summary>
  /// Создание
  /// </summary>
  /// <param name="item">объект</param>
  /// <returns>объект</returns>
  Task<TEntity> Create(TEntity item);

  /// <summary>
  /// Поиск объекта по идентификатору
  /// </summary>
  /// <param name="id">идентификатор</param>
  /// <returns>объект</returns>
  Task<TEntity?> FindById(Guid id);

  /// <summary>
  /// Список объектов
  /// </summary>
  /// <returns>Список объектов</returns>
  Task<IEnumerable<TEntity>> Get();

  /// <summary>
  /// Список объектов, с указанным условием
  /// </summary>
  /// <param name="predicate">условие</param>
  /// <returns>Список объектов, с указанным условием</returns>
  Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate);

  /// <summary>
  /// Удаление объекта
  /// </summary>
  /// <param name="item">объект</param>
  /// <returns>Результат удаления</returns>
  Task Remove(TEntity item);

  /// <summary>
  /// Изменение объекта
  /// </summary>
  /// <param name="Id">Идентификатор объекта</param>
  /// <param name="item">объект</param>
  /// <returns>объект</returns>
  Task<TEntity?> Update(Guid Id, TEntity item);
}