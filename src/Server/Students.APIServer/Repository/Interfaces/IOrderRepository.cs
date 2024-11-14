using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория приказов.
/// </summary>
public interface IOrderRepository : IGenericRepository<Order>
{
  /// <summary>
  /// Получить приказы.
  /// </summary>
  /// <returns>Приказы.</returns>
  public Task<PagedPage<OrderDTO>> GetOrderDTOByPage(int page, int pageSize);
}