using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер заявок.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class RequestController : GenericAPiController<Request>
{
    #region Поля и свойства

    private readonly IRequestRepository _requestRepository;

    #endregion

    #region Методы

    /// <summary>
    /// Создание новой заявки с фронта.
    /// </summary>
    /// <param name="form">DTO заявки с данными о потенциальном студенте.</param>
    /// <returns>Новая заявка (попутно создается новый студент, если не был найден).</returns>
    [HttpPost("NewRequest")]
    public async Task<IActionResult> Post([FromBody] NewRequestDTO form)
    {
        try
        {
            var result = await this._requestRepository.Create(form);
            return this.Ok(result);
        }
        catch (ArgumentException argEx)
        {
            this.Logger.LogWarning(argEx, "Invalid argument while creating Entity");
            return this.BadRequest(argEx.Message);
        }
        catch (InvalidOperationException invOpEx)
        {
            this.Logger.LogWarning(invOpEx, "Invalid operation while creating Entity");
            return this.BadRequest(invOpEx.Message);
        }
        catch (Exception e)
        {
            this.Logger.LogError(e, "Error while creating Entity");
            return this.Exception();
        }
    }

    /// <summary>
    /// Обновить заявку и её студента.
    /// </summary>
    /// <param name="id">Id заявки.</param>
    /// <param name="form">DTO заявки.</param>
    /// <returns>DTO заявки.</returns>
    [HttpPut("EditRequest/{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] RequestDTO form)
    {
        try
        {
            var result = await this._requestRepository.Update(id, form);
            return result is null ? this.NotFoundException() : this.Ok(form);
        }
        catch (ArgumentException argEx)
        {
            this.Logger.LogWarning(argEx, "Invalid argument while updating Entity");
            return this.BadRequest(argEx.Message);
        }
        catch (InvalidOperationException invOpEx)
        {
            this.Logger.LogWarning(invOpEx, "Invalid operation while updating Entity");
            return this.BadRequest(invOpEx.Message);
        }
        catch (Exception e)
        {
            this.Logger.LogError(e, "Error while updating Entity");
            return this.Exception();
        }
    }

    /// <summary>
    /// Добавление приказа.
    /// </summary>
    /// <param name="requestId">Идентификатор заявки.</param>
    /// <param name="order">Приказ.</param>
    /// <returns>Состояние запроса.</returns>
    [HttpPost("AddOrderToRequest")]
    public async Task<IActionResult> AddOrderToRequest(Guid requestId, [FromBody] Order order)
    {
        try
        {
            var request = await this._requestRepository.AddOrderToRequest(requestId, order);
            return request is null ? this.NotFoundException() : this.Ok();
        }
        catch (Exception e)
        {
            this.Logger.LogError(e, "Error while creating Entity");
            return this.Exception();
        }
    }

    /// <summary>
    /// Список заявок с разделением по страницам.
    /// </summary>
    /// <returns>Состояние запроса + список заявок с разделением по страницам.</returns>
    [HttpGet("paged")]
    public async Task<IActionResult> ListAllPagedDTO([FromQuery] Pageable pageable, [FromQuery] string? filterString = null, [FromQuery] string? sortingField = "StudentFullName", [FromQuery] bool isSortAsc = true)
    {
        try
        {
            if (string.IsNullOrEmpty(filterString))
            {
                filterString = "{}";
            }
            var items = await this._requestRepository.GetRequestDTOByPageFilteredSorted(pageable.PageNumber, pageable.PageSize, sortingField ?? "StudentFullName", isSortAsc, filterString!);
            return this.Ok(items);
        }
        catch (ArgumentException argEx)
        {
            this.Logger.LogWarning(argEx, "Invalid argument while creating Entity");
            return this.BadRequest(argEx.Message);
        }
        catch (InvalidOperationException invOpEx)
        {
            this.Logger.LogWarning(invOpEx, "Invalid operation while creating Entity");
            return this.BadRequest(invOpEx.Message);
        }
        catch (Exception e)
        {
            this.Logger.LogError(e, "Error while getting Entities");
            return this.Exception();
        }
    }

    /// <summary>
    /// Справочник статусов вступительного испытания
    /// </summary>
    /// <returns>Список статусов.</returns>
    [HttpGet("entranceExamStatuses")]
    public async Task<IActionResult> GetEntranceExamStatuses()
    {
        try
        {
            var statuses = await _requestRepository.GetEntranceExamStatuses();
            return this.Ok(statuses);
        }
        catch (ArgumentException argEx)
        {
            this.Logger.LogWarning(argEx, "Invalid argument while creating Entity");
            return this.BadRequest(argEx.Message);
        }
        catch (InvalidOperationException invOpEx)
        {
            this.Logger.LogWarning(invOpEx, "Invalid operation while creating Entity");
            return this.BadRequest(invOpEx.Message);
        }
        catch (Exception e)
        {
            this.Logger.LogError(e, "Error while getting entrance exam statuses");
            return this.Exception();
        }
    }

    /// <summary>
    /// Получение DTO заявки по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор заявки.</param>
    /// <returns>DTO заявки.</returns>
    [HttpGet("GetDTO/{id}")]
    public async Task<IActionResult> GetRequestDTO(Guid id)
    {
        try
        {
            var requestDTO = await this._requestRepository.GetRequestDTO(id);
            return requestDTO is null ? this.NotFoundException() : this.Ok(requestDTO);
        }
        catch (ArgumentException argEx)
        {
            this.Logger.LogWarning(argEx, "Invalid argument while creating Entity");
            return this.BadRequest(argEx.Message);
        }
        catch (InvalidOperationException invOpEx)
        {
            this.Logger.LogWarning(invOpEx, "Invalid operation while creating Entity");
            return this.BadRequest(invOpEx.Message);
        }
        catch (Exception e)
        {
            this.Logger.LogError(e, "Error while getting Entity by Id");
            return this.Exception();
        }
    }
    #endregion

    #region Базовый класс

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="logger">Логгер.</param>
    /// <param name="requestRepository">Репозиторий заявок.</param>
    public RequestController(IRequestRepository requestRepository,
    ILogger<Request> logger) : base(requestRepository, logger)
    {
        this._requestRepository = requestRepository;
    }

    #endregion
}