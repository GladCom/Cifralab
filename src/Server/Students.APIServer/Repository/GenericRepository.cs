using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий Generic.
/// </summary>
/// <typeparam name="TEntity">Сущность, с которой работает репозиторий.</typeparam>
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
  #region Поля и свойства

  private readonly StudentContext _context;
  private readonly DbSet<TEntity> _dbSet;

  #endregion

  #region Методы

  /// <summary>
  /// Получение списка сущностей с загрузкой из базы данных.
  /// </summary>
  /// <returns>Список сущностей с загрузкой из базы данных.</returns>
  public async Task<IEnumerable<TEntity>> Get()
  {
    return await _dbSet.AsNoTracking().ToListAsync();
  }

  /// <summary>
  /// Получение списка сущностей.
  /// </summary>
  /// <param name="predicate">Функция, по условию которой производится отбор данных из БД.</param>
  /// <returns>Список сущностей.</returns>
  public async Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate)
  {
    return await _dbSet.AsNoTracking().AsEnumerable().Where(predicate).AsQueryable().ToListAsync();
  }

  /// <summary>
  /// Поиск сущности по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор сущности.</param>
  /// <returns>Сущность.</returns>
  public virtual async Task<TEntity?> FindById(Guid id)
  {
    return await _dbSet.FindAsync(id);
  }

  /// <summary>
  /// Создание сущности.
  /// </summary>
  /// <param name="item">Сущность.</param>
  /// <returns>Сущность.</returns>
  public virtual async Task<TEntity> Create(TEntity item)
  {
    _dbSet.Add(item);
    await _context.SaveChangesAsync();
    return item;
  }

  /// <summary>
  /// Изменение сущности.
  /// </summary>
  /// <param name="id">Идентификатор сущности.</param>
  /// <param name="item">Обновлённая сущность.</param>
  /// <returns>Сущность.</returns>
  public async Task<TEntity?> Update(Guid id, TEntity item)
  {
    var oldItem = await _dbSet.FindAsync(id);
    if(oldItem == null)
    {
      return null;
    }

    item.GetType().GetProperty("Id")?.SetValue(item, id);
    _context.Entry(oldItem).CurrentValues.SetValues(item);
    await _context.SaveChangesAsync();
    return item;
  }

  /// <summary>
  /// Удаление сущности.
  /// </summary>
  /// <param name="item">Сущность.</param>
  /// <returns>Результат удаления.</returns>
  public async Task Remove(TEntity item)
  {
    _dbSet.Remove(item);
    await _context.SaveChangesAsync();
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  public GenericRepository(StudentContext context)
  {
    _context = context;
    _dbSet = context.Set<TEntity>();
  }

  #endregion
}