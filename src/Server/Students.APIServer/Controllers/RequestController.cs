using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;
using Students.Models.WebModels;

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

  private readonly ILogger<Request> _logger;
  private readonly IRequestRepository _requestRepository;
  private readonly IStudentRepository _studentRepository;
  private readonly IGenericRepository<StatusRequest> _statusRequestRepository;

  #endregion

  #region Методы

  //это лишнее, это копия базового метода
  /// <summary>
  /// Получение заявки по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <returns>Заявка.</returns>
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

  /// <summary>
  /// Создание новой заявки с фронта.
  /// </summary>
  /// <param name="requestDTO">DTO заявки с данными о потенциальном студенте.</param>
  /// <returns>Новая заявка (попутно создается новый студент, если не был найден).</returns>
  [HttpPost("NewRequest")]
  public async Task<IActionResult> Post([FromBody] NewRequestDTO requestDTO)
  {
    Request request = new Request
    {
      //Id = requestDTO.Id ?? default,
      //StudentId = requestDTO.StudentId,
      EducationProgramId = requestDTO.educationProgramId,
      //DocumentRiseQualificationId = requestDTO.
      StatusRequestId = _statusRequestRepository.Get().Result?.FirstOrDefault(x => x.Name?.ToLower() == "новая заявка")
        ?.Id,
      StatusEntrancExams = (StatusEntrancExams)requestDTO.statusEntranceExams,
      Email = requestDTO.email ?? "",
      Phone = requestDTO.phone,
      Agreement = requestDTO.agreement
    };

    var fio = $"{requestDTO.family} {requestDTO.name} {requestDTO.patron}";
    var date = DateOnly.FromDateTime(DateTime.Parse(requestDTO.birthDate));

    var student = _studentRepository.Get().Result.FirstOrDefault(x =>
      x.FullName == fio && x.BirthDate == date && x.Email == requestDTO.email);

    if (student == null)
    {
      request.IsAlreadyStudied = false;
      if (!_studentRepository.Get().Result.Any(x =>
            x.FullName == fio || x.BirthDate == date || x.Email == requestDTO.email))
      {
        student = new Student
        {
          Address = requestDTO.address!,
          Family = requestDTO.family ?? "",
          Name = requestDTO.name,
          Patron = requestDTO.patron,

          BirthDate = date,
          IT_Experience = requestDTO.iT_Experience!,
          Email = requestDTO.email!,
          Phone = requestDTO.phone ?? "",
          Sex = SexHuman.Men,
          TypeEducationId = requestDTO.typeEducationId,
          ScopeOfActivityLevelOneId = requestDTO.scopeOfActivityLevelOneId,
          ScopeOfActivityLevelTwoId = requestDTO.scopeOfActivityLevelTwoId
        };

        student = await _studentRepository.Create(student);
      }
    }
    else
    {
      request.IsAlreadyStudied = true;
    }

    request.StudentId = student?.Id;
    request.Student = student;

    //var result = await _requestRepository.Create(request);

    try
    {
      var form = await _requestRepository.Create(request);
      if (form is null)
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
  /// Создание новой заявки.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <returns>Состояние запроса + Заявка.</returns>
  public override async Task<IActionResult> Post(Request request)
  {
    try
    {
      if (request.StudentId is not null)
      {
        var existingStudentRequests = await _studentRepository.GetListRequestsOfStudentExists(request.StudentId.Value);
        request.IsAlreadyStudied = existingStudentRequests is not null && existingStudentRequests.Any();
      }

      var form = await _requestRepository.Create(request);
      if (form is null)
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
  /// Добавление приказа.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <param name="order">Приказ.</param>
  /// <returns>Состояние запроса.</returns>
  [HttpPost("AddOrderToRequest")]
  public async Task<ActionResult> AddOrderToRequest(Guid id, Order order)
  {
    await _requestRepository.AddOrderToRequest(id, order);
    return StatusCode(StatusCodes.Status200OK);
  }

  /*
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
  */


  /// <summary>
  /// Список заявок с разделением по страницам.
  /// </summary>
  /// <returns>Состояние запроса + список заявок с разделением по страницам.</returns>
  [HttpGet("paged")]
  public async Task<IActionResult> ListAllPagedDTO([FromQuery] Pageable pageable)
  {
    var items = await _requestRepository.GetRequestsDTOByPage(pageable.PageNumber, pageable.PageSize);
    return StatusCode(StatusCodes.Status200OK, items);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий заявок.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="requestRepository">Репозиторий заявок (как будто лучше использовать этот параметр вместо двух???).</param>
  /// <param name="statusRequestRepository">Репозиторий состояний заявок.</param>
  /// <param name="studentRepository">Репозиторий студентов).</param>
  public RequestController(IGenericRepository<Request> repository, ILogger<Request> logger,
    IRequestRepository requestRepository, IGenericRepository<StatusRequest> statusRequestRepository,
    IStudentRepository studentRepository) : base(repository, logger)
  {
    _requestRepository = requestRepository;
    _statusRequestRepository = statusRequestRepository;
    _studentRepository = studentRepository;
    _logger = logger;
  }

  #endregion
}