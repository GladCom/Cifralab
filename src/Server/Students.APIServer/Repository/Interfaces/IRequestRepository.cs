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
  /// Поиск заявок по номеру телефона из заявки.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <returns>Заявка.</returns>
  Task<Request?> FindRequestByPhoneFromRequestAsync(Request request);

  /// <summary>
  /// Поиск заявок по mail из заявки.
  /// </summary>
  /// <param name="request">Электронная почта.</param>
  /// <returns>Заявка.</returns>
  Task<Request?> FindRequestByEmailFromRequestAsync(Request request);

  /// <summary>
  /// Добавление приказа в заявку.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <param name="order">Приказ.</param>
  /// <returns>Идентификатор заявки.</returns>
  Task<Guid> AddOrderToRequest(Guid id, Order order);

  /// <summary>
  /// Пагинация заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Пагинированные DTO заявок.</returns>
  Task<PagedPage<Request>> GetRequestsByPage(int page, int pageSize);

  /// <summary>
  /// Пагинация заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Пагинированные DTO заявок.</returns>
  Task<PagedPage<RequestsDTO>> GetRequestsDTOByPage(int page, int pageSize);
}