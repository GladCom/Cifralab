using Microsoft.EntityFrameworkCore;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
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



  #endregion

  #region IOrderRepository

  /// <summary>
  /// Пагинация приказов.
  /// </summary>
  /// <returns>Приказы.</returns>
  public async Task<PagedPage<OrderDTO>> GetOrderDTOByPage(int page, int pageSize)
  {
    var query = this.DbSet
      .Include(k => k.KindOrder)
      .Include(r => r.Request)
      .ThenInclude(s => s!.Student)
      .ThenInclude(g => g!.Groups)
      .Select(order => Mapper.OrderToOrderDTO(order).Result);

    return await PagedPage<OrderDTO>.ToPagedPage<string>(query, page, pageSize, x => x.StudentName);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public OrderRepository(StudentContext context) : base(context)
  {
  }

  #endregion
}