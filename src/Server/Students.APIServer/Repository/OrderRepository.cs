using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий приказов.
/// </summary>
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
  #region Поля и свойства

  private readonly StudentContext _context;

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public OrderRepository(StudentContext context) : base(context)
  {
    _context = context;
  }

  #endregion
}