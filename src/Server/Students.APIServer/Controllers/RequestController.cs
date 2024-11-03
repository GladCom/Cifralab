using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
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

  /// <summary>
  /// Получение заявки по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <returns>Заявка.</returns>
  public override async Task<IActionResult> Get(Guid id)
  {
    try
    {
      var form = await this._requestRepository.FindById(id);
      if (form == null)
      {
        return this.StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
          });
      }

      var requestsDTO = await Mapper.RequestToRequestDTO(form);

      return this.StatusCode(StatusCodes.Status200OK, requestsDTO);
    }
    catch (Exception e)
    {
      this._logger.LogError(e, "Error while getting Entity by Id");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
        });
    }
  }

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
      var request = await Mapper.NewRequestDTOToRequest(form, this._statusRequestRepository);

      var fio = $"{form.family} {form.name} {form.patron}";
      var date = form.birthDate;

      var student = await this._studentRepository.GetOne(x =>
        x.Name == form.name && x.Family == form.family && x.Patron == form.patron && x.BirthDate == date && x.Email == form.email);

      if (student == null)
      {
        request.IsAlreadyStudied = false;
        if (!this._studentRepository.Get().Result.Any(x =>
              x.FullName == fio || x.BirthDate == date || x.Email == form.email))
        {
          student = await Mapper.NewRequestDTOToStudent(form);
          student = await this._studentRepository.Create(student);
        }
      }
      else
      {
        request.IsAlreadyStudied = true;
      }

      request.StudentId = student?.Id;

      var result = await this._requestRepository.Create(request);
      if (result is null)
      {
        return this.StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
          });
      }

      return this.StatusCode(StatusCodes.Status200OK, result);
    }
    catch (Exception e)
    {
      this._logger.LogError(e, "Error while getting Entity by Id");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
        });
    }
  }

  /// <summary>
  /// Обновить объект.
  /// Пизда, а не мокап, студента выбирать нужно из списка блять
  /// </summary>
  /// <param name="id">Id объекта.</param>
  /// <param name="form">Объект.</param>
  /// <returns>Объект.</returns>
  [HttpPut("EditRequest/{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] RequestsDTO form)
  {
    try
    {
      var resultOld = await this._requestRepository.FindById(id);

      if (resultOld is null)
      {
        throw new Exception($"{id} Такой заявки нет");
      }

      Student? student;

      //Если студент уже привязан, то меняем его реквизиты, но если он совпадет по трем полям с уже существующим, то пусть идут в топку
      if (form.StudentId is not null)
      {
        student = await this._studentRepository.FindById(form.StudentId.Value);
        if (student is not null)
        {
          var tempNewStudent = await this._studentRepository.GetOne(x => x.Phone == form.phone &&
                                                                         x.Email == form.Email &&
                                                                         x.Family == form.family &&
                                                                         x.Name == form.name! &&
                                                                         x.Patron == form.patron!);

          if (tempNewStudent is not null && student.Id != tempNewStudent.Id)
          {
            //throw new Exception("Попытка задублировать студентов");
            student = tempNewStudent;
          }

          student.Family = form.family!;
          student.Name = form.name;
          student.Patron = form.patron;
          student.BirthDate = (DateOnly)form.BirthDate!;
          student.Sex = default;
          student.Address = form.Address!;
          student.Phone = form.phone ?? "";
          student.Email = form.Email ?? "";
          student.Projects = form.projects;
          student.IT_Experience = form.IT_Experience!;
          student.TypeEducationId = form.TypeEducationId;
          //Ебать-кололить, нет этого в мокапе, и не нужно было бы, коли выбор был бы из списка, короче этот метод нужно переделывать
          student.ScopeOfActivityLevelOneId = student.ScopeOfActivityLevelOneId != Guid.Empty
            ? student.ScopeOfActivityLevelOneId
            : Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34");
          student.Speciality = form.speciality;

          resultOld.StudentId = student.Id;
          await this._studentRepository.Update(student.Id, student);
        }
      }
      else
      {
        student = await this._studentRepository.GetOne(x => x.Phone == form.phone &&
                                                            x.Email == form.Email &&
                                                            x.Family == form.family! &&
                                                            x.Name == form.name! &&
                                                            x.Patron == form.patron!);

        if (student is null)
        {
          student = await Mapper.RequestDTOToStudent(form);

          student = await this._studentRepository.Create(student);
          resultOld.StudentId = student.Id;
        }
      }

      resultOld.StatusRequestId = form!.StatusRequestId;
      resultOld.StatusEntrancExams = form.statusEntrancExams;
      resultOld.Email = form.Email ?? "";
      resultOld.Phone = form.phone ?? "";
      resultOld.Agreement = form.agreement;
      resultOld.EducationProgramId = form.EducationProgramId;

      var result = await this._requestRepository.Update(id, resultOld);
      if (result == null)
      {
        return this.StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
          });
      }

      return this.StatusCode(StatusCodes.Status200OK, form);
    }
    catch (Exception e)
    {
      this._logger.LogError(e, "Error while updating Entity");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
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
        var existingStudentRequests =
          await this._requestRepository.Get(r => r.StudentId == request.StudentId);
        request.IsAlreadyStudied = existingStudentRequests.Any();
      }

      var form = await this._requestRepository.Create(request);
      if (form is null)
      {
        return this.StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
          });
      }

      return this.StatusCode(StatusCodes.Status200OK, form);
    }
    catch (Exception e)
    {
      this._logger.LogError(e, "Error while getting Entity by Id");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
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
    await this._requestRepository.AddOrderToRequest(id, order);
    return this.StatusCode(StatusCodes.Status200OK);
  }

  /// <summary>
  /// Список с заявками, которые подавал студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список заявок.</returns>
  [HttpGet("GetListRequestsOfStudentExists")]
  public async Task<IActionResult> GetListRequestsOfStudentExists(Guid studentId)
  {
    return this.StatusCode(StatusCodes.Status200OK,
      await this._requestRepository.Get(r => r.StudentId == studentId));
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
    var items = await this._requestRepository.GetRequestsDTOByPage(pageable.PageNumber, pageable.PageSize);
    return this.StatusCode(StatusCodes.Status200OK, items);
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
    this._requestRepository = requestRepository;
    this._statusRequestRepository = statusRequestRepository;
    this._studentRepository = studentRepository;
    this._logger = logger;
  }

  #endregion
}