using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория заявки.
/// </summary>
public interface IRequestRepository : IGenericRepository<Request>
{
  /// <summary>
  /// Добавление приказа в заявку.
  /// </summary>
  /// <param name="requestId">Идентификатор заявки.</param>
  /// <param name="order">Приказ.</param>
  /// <returns>Идентификатор заявки.</returns>
  Task<Guid?> AddOrderToRequest(Guid requestId, Order order);

  /// <summary>
  /// Пагинация заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Пагинированные DTO заявок.</returns>
  Task<PagedPage<RequestsDTO>> GetRequestsDTOByPage(int page, int pageSize);

  /// <summary>
  /// Поиск заявки с подгрузкой связанных сущностей.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <returns>Заявка с подгруженными сущностями.</returns>
  Task<Request?> GetRequestForDTO(Guid id);
}