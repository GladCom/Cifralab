using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Filters.Filters;
using Students.Models.Searches.Searches;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий Generic.
/// </summary>
/// <typeparam name="TEntity">Сущность, с которой работает репозиторий.</typeparam>
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
  #region Поля и свойства

  /// <summary>
  /// Контекст репозитория.
  /// </summary>
  protected readonly StudentContext _context;

  /// <summary>
  /// DbSet репозитория.
  /// </summary>
  protected DbSet<TEntity> DbSet { get; }

  #endregion

  #region IGenericRepository

  /// <summary>
  /// Получение списка сущностей с загрузкой из базы данных.
  /// </summary>
  /// <returns>Список сущностей с загрузкой из базы данных.</returns>
  public async Task<IEnumerable<TEntity>> Get()
  {
    return await this.DbSet.AsNoTracking().ToListAsync();
  }

  /// <summary>
  /// Получение списка сущностей.
  /// </summary>
  /// <param name="dbSet">Модифицированный набор сущностей.</param>
  /// <param name="predicate">Функция, по условию которой производится отбор данных из БД.</param>
  /// <returns>Список сущностей.</returns>
  public async Task<IEnumerable<TEntity>> Get(Predicate<TEntity> predicate, IQueryable<TEntity>? dbSet = null)
  {
    var items = new List<TEntity>();
    await foreach(var item in (dbSet ?? this.DbSet).AsNoTracking().AsAsyncEnumerable())
    {
      if(predicate(item))
        items.Add(item);
    }

    return items;
  }

  /// <summary>
  /// Получение подходящей сущности.
  /// </summary>
  /// <param name="dbSet">Модифицированный набор сущностей.</param>
  /// <param name="predicate">Функция, по условию которой производится отбор данных из БД.</param>
  /// <returns>Сущность.</returns>
  public async Task<TEntity?> GetOne(Predicate<TEntity> predicate, IQueryable<TEntity>? dbSet = null)
  {
    await foreach(var item in (dbSet ?? this.DbSet).AsAsyncEnumerable())
    {
      if(predicate(item))
        return item;
    }

    return null;
  }

  //Метод для перегрузки и явного указания подгружаемых полей.
  /// <summary>
  /// Получение списка сущностей.
  /// </summary>
  /// <param name="filter">Фильтр по которому происходит отбор.</param>
  /// <returns>Список сущностей.</returns>
  public virtual async Task<IEnumerable<TEntity>> GetFiltered(Filter<TEntity> filter)
  {
    return await this.Get(filter.GetFilterPredicate());
  }

  /// <inheritdoc />
  public virtual async Task<IEnumerable<TEntity>> GetSearched(Search<TEntity> search)
  {
    IQueryable<TEntity> query = this.DbSet;

    if (typeof(TEntity) == typeof(Request))
    {
      query = query.Include(e => ((Request)(object)e).Student) as IQueryable<TEntity>;
    }

    return await this.Get(search.GetSearchPredicate(), query);
  }

  /// <summary>
  /// Поиск сущности по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор сущности.</param>
  /// <returns>Сущность.</returns>
  public async Task<TEntity?> FindById(Guid id)
  {
    return await this.DbSet.FindAsync(id);
  }

  /// <summary>
  /// Создание сущности.
  /// </summary>
  /// <param name="item">Сущность.</param>
  /// <returns>Сущность.</returns>
  public virtual async Task<TEntity> Create(TEntity item)
  {
    this.DbSet.Add(item);
    await this._context.SaveChangesAsync();
    return item;
  }

  /// <summary>
  /// Изменение сущности.
  /// </summary>
  /// <param name="id">Идентификатор сущности.</param>
  /// <param name="item">Обновлённая сущность.</param>
  /// <returns>Сущность.</returns>
  public virtual async Task<TEntity?> Update(Guid id, TEntity item)
  {
    var oldItem = await this.DbSet.FindAsync(id);
    if(oldItem == null)
    {
      return null;
    }

    item.GetType().GetProperty("Id")?.SetValue(item, id);
    this._context.Entry(oldItem).CurrentValues.SetValues(item);
    await this._context.SaveChangesAsync();
    return item;
  }

  /// <summary>
  /// Удаление сущности.
  /// </summary>
  /// <param name="item">Сущность.</param>
  /// <returns>Результат удаления.</returns>
  public async Task Remove(TEntity item)
  {
    this.DbSet.Remove(item);
    await this._context.SaveChangesAsync();
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  public GenericRepository(StudentContext context)
  {
    this._context = context;
    this.DbSet = context.Set<TEntity>();
  }

  #endregion
}