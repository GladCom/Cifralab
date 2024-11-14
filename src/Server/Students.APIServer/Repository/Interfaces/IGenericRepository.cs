using Students.Models.Filters.Filters;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс generic репозитория.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IGenericRepository<TEntity> where TEntity : class
{
  /// <summary>
  /// Создание.
  /// </summary>
  /// <param name="item">Объект.</param>
  /// <returns>Объект.</returns>
  Task<TEntity> Create(TEntity item);

  /// <summary>
  /// Поиск объекта по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  /// <returns>Объект.</returns>
  Task<TEntity?> FindById(Guid id);

  /// <summary>
  /// Список объектов.
  /// </summary>
  /// <returns>Список объектов.</returns>
  Task<IEnumerable<TEntity>> Get();

  /// <summary>
  /// Получение списка сущностей.
  /// </summary>
  /// <param name="dbSet">Модифицированный набор сущностей.</param>
  /// <param name="predicate">Функция, по условию которой производится отбор данных из БД.</param>
  /// <returns>Список сущностей.</returns>
  Task<IEnumerable<TEntity>> Get(Predicate<TEntity> predicate, IQueryable<TEntity>? dbSet = null);

  /// <summary>
  /// Получение подходящей сущности.
  /// </summary>
  /// <param name="dbSet">Модифицированный набор сущностей.</param>
  /// <param name="predicate">Функция, по условию которой производится отбор данных из БД.</param>
  /// <returns>Сущность.</returns>
  Task<TEntity?> GetOne(Predicate<TEntity> predicate, IQueryable<TEntity>? dbSet = null);

  //Метод для перегрузки и явного указания подгружаемых полей.
  /// <summary>
  /// Получение списка сущностей.
  /// </summary>
  /// <param name="filter">Фильтр по которому происходит отбор.</param>
  /// <returns>Список сущностей.</returns>
  Task<IEnumerable<TEntity>> GetFiltered(Filter<TEntity> filter);

  /// <summary>
  /// Удаление объекта.
  /// </summary>
  /// <param name="item">Объект.</param>
  /// <returns>Результат удаления.</returns>
  Task Remove(TEntity item);

  /// <summary>
  /// Изменение объекта.
  /// </summary>
  /// <param name="id">Идентификатор объекта.</param>
  /// <param name="item">Объект.</param>
  /// <returns>Объект.</returns>
  Task<TEntity?> Update(Guid id, TEntity item);
}