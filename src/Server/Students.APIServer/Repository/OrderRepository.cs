using Microsoft.EntityFrameworkCore;
using Students.APIServer.DTO;
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

  #region Методы

  /// <summary>
  /// Список приказов с информацией о студентах.
  /// </summary>
  /// <returns>Приказы.</returns>
  public async Task<IEnumerable<OrderDTO>> GetListOrdersWithStudentAsync()
  {
    var orders = await _context.Orders
      .Include(k => k.KindOrder)
      .Include(r => r.Request)
      .ThenInclude(s => s != null ? s.Student : null)
      .ThenInclude(g => g != null ? g.Groups : null)
      .Select(order => new OrderDTO()
      {
        Id = order.Id,
        Date = order.Date,
        Number = order.Number,
        StudentName = order.Request != null && order.Request.Student != null ? order.Request.Student.FullName : null,
        KindOrderName = order.KindOrder != null ? order.KindOrder.Name : null,
        Groups = order.Request != null && order.Request.Student != null && order.Request.Student.Groups != null ? 
          order.Request.Student.Groups : null
      })
      .ToListAsync();

    return orders;
  }

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