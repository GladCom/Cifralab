using System.Diagnostics;
using System.Text.Json.Serialization;
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
      else
      {
        var requestsDTO = new RequestsDTO()
        {
            StudentFullName = form.Student?.FullName ?? "",
            family = form.Student?.Family,
            name = form.Student?.Name,
            patron = form.Student?.Patron,
            StatusRequest = form.Status?.Name,
            StatusRequestId = form.StatusRequestId,
            EducationProgram = form.EducationProgram?.Name,
            EducationProgramId = form.EducationProgramId,
            TypeEducation = form.Student?.TypeEducation?.Name,
            TypeEducationId = form.Student?.TypeEducationId,
            speciality = form.Student?.Speciality,
            IT_Experience = form.Student?.IT_Experience,
            projects = form.Student?.Projects,
            statusEntrancExams = form.StatusEntrancExams ?? 0,
            BirthDate = form.Student?.BirthDate,
            Age = form.Student?.Age,
            Address = form.Student?.Address,
            phone = form.Student?.Phone,
            Email = form.Student?.Email,
            agreement = form.Agreement
        };

        return StatusCode(StatusCodes.Status200OK, requestsDTO);

    }
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
    /// Обновить объект.
    /// Пизда, а не мокап, студента выбирать нужно из списка блять
    /// </summary>
    /// <param name="id">Id объекта.</param>
    /// <param name="form">Объект.</param>
    /// <returns>Объект.</returns>
    [HttpPut("EditRequest/{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] RequestsDTO form)
    {
        var resultOld = await _requestRepository.FindById(id);
        var student = await _studentRepository.FindByPhoneAndEmail(form?.phone ?? "-----", form?.Email ?? "-----");

        if (resultOld != null)
        {
            if (student != null && student.Name == form!.name && student.Family == form!.family && student.Patron == form!.patron)
            {
                resultOld.StudentId = student!.Id;

                student.Family = form!.family!;
                student.Name = form?.name;
                student.Patron = form?.patron;
                student.BirthDate = (DateOnly)form!.BirthDate!;
                student.Sex = default;
                student.Address = form.Address!;
                student.Phone = form.phone!;
                student.Email = form.Email!;
                student.Projects = form.projects;
                student.IT_Experience = form!.IT_Experience!;
                student.TypeEducationId = form.TypeEducationId;
                //Ебать-кололить, нет этого в мокапе, и не нужно было бы, коли выбор был бы из списка, короче этот метод нужно переделывать
                student.ScopeOfActivityLevelOneId = student.ScopeOfActivityLevelOneId != Guid.Empty ? student.ScopeOfActivityLevelOneId : Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34");
                student.Speciality = form.speciality;
            }
            else
            {
                if (student == null)
                {
                    student = new Student()
                    {
                        Family = form!.family,
                        Name = form?.name,
                        Patron = form?.patron,
                        BirthDate = (DateOnly)form!.BirthDate,
                        Sex = default,
                        Address = form.Address,
                        Phone = form.Address,
                        Email = form.Email,
                        Projects = form.projects,
                        IT_Experience = form.IT_Experience,
                        TypeEducationId = form.TypeEducationId,
                        //Ебать-кололить
                        ScopeOfActivityLevelOneId = Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34"),
                        Speciality = form.speciality
                    };

                    var resultStudent = await _studentRepository.Create(student);
                    resultOld.StudentId = student!.Id;
                }
                else
                {
                    student.Family = form!.family!;
                    student.Name = form?.name;
                    student.Patron = form?.patron;
                    student.BirthDate = (DateOnly)form!.BirthDate!;
                    student.Sex = student.Sex;
                    student.Address = form.Address!;
                    student.Phone = form.phone!;
                    student.Email = form.Email!;
                    student.Projects = form.projects;
                    student.IT_Experience = form!.IT_Experience!;
                    student.TypeEducationId = form.TypeEducationId;
                    //Ебать-кололить, нет этого в мокапе, и не нужно было бы, коли выбор был бы из списка, короче этот метод нужно переделывать
                    student.ScopeOfActivityLevelOneId = student.ScopeOfActivityLevelOneId != Guid.Empty ? student.ScopeOfActivityLevelOneId : Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34");
                    student.Speciality = form.speciality;
                }
            }

            resultOld.StatusRequestId = form!.StatusRequestId;
            resultOld.StatusEntrancExams = form!.statusEntrancExams;
            resultOld.Email = form!.Email ?? "";
            resultOld.Phone = form!.phone ?? "";
            resultOld.Agreement = form!.agreement;
        };

        try
        {
            var resultStudent = await _studentRepository.Update(student!.Id, student!);

            var result = await _requestRepository.Update(id, resultOld!);
            if (result == null)
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
            _logger.LogError(e, "Error while updating Entity");
            return StatusCode(StatusCodes.Status500InternalServerError,
              new DefaultResponse
              {
                  RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
              });
        }
    }

    //это лишнее, это копия базового метода
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