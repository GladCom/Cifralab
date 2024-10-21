using Students.APIServer.DTO;
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
  public Task<IEnumerable<OrderDTO>> GetListOrdersWithStudentAsync();
}