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
  /// Создание новой заявки с фронта.
  /// </summary>
  /// <param name="form">DTO заявки с данными о потенциальном студенте.</param>
  /// <returns>Новая заявка (попутно создается новый студент, если не был найден).</returns>
  Task<Request> Create(NewRequestDTO form);

  /// <summary>
  /// Обновить заявку и её студента.
  /// Пизда, а не мокап, студента выбирать нужно из списка блять
  /// </summary>
  /// <param name="requestId">Id заявки.</param>
  /// <param name="form">DTO заявки.</param>
  /// <returns>DTO заявки.</returns>
  Task<RequestDTO?> Update(Guid requestId, RequestDTO form);

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
  Task<PagedPage<RequestDTO>> GetRequestsDTOByPage(int page, int pageSize);

  /// <summary>
  /// Поиск заявки с подгрузкой связанных сущностей.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <returns>Заявка с подгруженными сущностями.</returns>
  Task<RequestDTO?> GetRequestDTO(Guid id);
}