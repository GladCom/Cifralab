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
    /// Создание новой заявки с тильды.
    /// </summary>
    /// <param name="form">DTO с тильды с данными о потенциальном студенте.</param>
    /// <returns>Новая заявка (попутно создается новый студент, если не был найден).</returns>
    Task<RequestWebhook> Create(RequestWebhook form);

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
    /// Пагинация, фильтрация и сортировка заявок
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="sortingField">Сортировочное поле</param>
    /// <param name="isAsc">Направление сортировки. true - asc, false - desc</param>
    /// <param name="filterString">Строка фильтрации</param>
    /// <returns>Страница с заявками</returns>
    Task<PagedPage<RequestDTO>> GetRequestDTOByPageFilteredSorted(int page, int pageSize, string sortingField, bool isAsc, string filterString);

    /// <summary>
    /// Все статусы вступительных испытаний
    /// </summary>
    /// <returns>Статусы вступительных испытаний</returns>
    Task<List<EntranceStatusDTO>> GetEntranceExamStatuses();

    /// <summary>
    /// Поиск заявки с подгрузкой связанных сущностей.
    /// </summary>
    /// <param name="id">Идентификатор заявки.</param>
    /// <returns>Заявка с подгруженными сущностями.</returns>
    Task<RequestDTO?> GetRequestDTO(Guid id);
}