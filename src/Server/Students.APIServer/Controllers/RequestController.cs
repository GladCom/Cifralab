using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.Models;
using System.Diagnostics;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер заявок
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class RequestController : GenericAPiController<Request>
{
    private readonly ILogger<Request> _logger;
    private readonly IRequestRepository _requestRepository;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="repository">Репозиторий заявок</param>
    /// <param name="logger">Логгер</param>
    /// <param name="requestRepository">Репозиторий заявок (как-будто лучше использовать этот параметр вместо двух???)</param>
    public RequestController(IGenericRepository<Request> repository, ILogger<Request> logger, IRequestRepository requestRepository) : base(repository, logger)
    {
        _requestRepository = requestRepository;
        _logger = logger;
    }

    //это лишнее, это копия базового метода
    /// <summary>
    /// Получение завяки по идентификатору
    /// </summary>
    /// <param name="id">идентификатор заявки</param>
    /// <returns></returns>
    public override async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var form = await _requestRepository.FindById(id);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }

    //это лишнее, это копия базового метода
    /// <summary>
    /// Создание новой заявки
    /// </summary>
    /// <param name="request">заявка</param>
    /// <returns>Состояние запроса + Заявка</returns>
    public override async Task<IActionResult> Post(Request request)
    {
        try
        {
            var form = await _requestRepository.Create(request);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }

    /// <summary>
    /// Добавление приказа
    /// </summary>
    /// <param name="id">Идентификатор заявки</param>
    /// <param name="order">Приказ</param>
    /// <returns>Состояние запроса</returns>
    [HttpPost("AddOrderToRequest")]
    public async Task<ActionResult> AddOrderToRequest(Guid id, Order order)
    {
        await _requestRepository.AddOrderToRequest(id, order);
        return StatusCode(StatusCodes.Status200OK);
    }

    /// <summary>
    /// Список заявок с разделением по страницам
    /// </summary>
    /// <returns>Состояние запроса + список заявок с разделением по страницам </returns>
    [HttpGet("paged")]
    public async Task<IActionResult> ListAllPaged([FromQuery] Pageable pageable)
    {
        var items = await _requestRepository.GetRequestsByPage(pageable.PageNumber, pageable.PageSize);
        return StatusCode(StatusCodes.Status200OK, items);
    }
}
    
