using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.ReferenceModels;

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
  private readonly IStudentRepository _studentRepository;
  private readonly IGenericRepository<StatusRequest> _statusRequestRepository;

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
      var request = await Mapper.NewRequestDTOToRequest(form, this._statusRequestRepository);

      var fio = $"{form.family} {form.name} {form.patron}";
      var date = form.birthDate;

      var student = await this._studentRepository.GetOne(x =>
        x.Name == form.name && x.Family == form.family && x.Patron == form.patron && x.BirthDate == date && x.Email == form.email);

      if(student is null)
      {
        request.IsAlreadyStudied = false;
        if(await this._studentRepository.GetOne(x =>
             x.FullName == fio || x.BirthDate == date || x.Email == form.email) is null)
        {
          student = await Mapper.NewRequestDTOToStudent(form);
          student = await this._studentRepository.Create(student);
        }
      }

      request.StudentId = student?.Id;

      var result = await this._requestRepository.Create(request);
      return this.Ok(result);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while creating Entity");
      return this.Exception();
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

      if(resultOld is null)
      {
        return this.NotFoundException();
      }

      Student? student;

      //Если студент уже привязан, то меняем его реквизиты, но если он совпадет по трем полям с уже существующим, то пусть идут в топку
      if(form.StudentId is not null)
      {
        student = await this._studentRepository.FindById(form.StudentId.Value);
        if(student is not null)
        {
          var tempNewStudent = await this._studentRepository.GetOne(x => x.Phone == form.phone &&
                                                                         x.Email == form.Email &&
                                                                         x.Family == form.family &&
                                                                         x.Name == form.name! &&
                                                                         x.Patron == form.patron!);

          if(tempNewStudent is not null && student.Id != tempNewStudent.Id)
          {
            //throw new Exception("Попытка задублировать студентов");
            student = tempNewStudent;
          }

          student.Family = form.family!;
          student.Name = form.name;
          student.Patron = form.patron;
          student.BirthDate = (DateOnly)form.BirthDate!;
          student.Sex = student.Sex;
          student.Address = form.Address!;
          student.Phone = form.phone ?? "";
          student.Email = form.Email ?? "";
          student.Projects = form.projects;
          student.IT_Experience = form.IT_Experience!;
          student.TypeEducationId = form.TypeEducationId;
          //Ебать-кололить, нет этого в мокапе, и не нужно было бы, коли выбор был бы из списка, короче этот метод нужно переделывать
          student.ScopeOfActivityLevelOneId = form.ScopeOfActivityLevelOneId != null && (Guid)form.ScopeOfActivityLevelOneId! != Guid.Empty
            ? (Guid)form.ScopeOfActivityLevelOneId
            : Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34");
          student.ScopeOfActivityLevelTwoId = form.ScopeOfActivityLevelTwoId;
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

        if(student is null)
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

      await this._requestRepository.Update(id, resultOld);

      //var result = await this.Get(id);

      return this.Ok(form);
    }
    catch(Exception e)
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
    catch(Exception e)
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
  public async Task<IActionResult> ListAllPagedDTO([FromQuery] Pageable pageable)
  {
    try
    {
      var items = await this._requestRepository.GetRequestsDTOByPage(pageable.PageNumber, pageable.PageSize);
      return this.Ok(items);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entities");
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
      var form = await this._requestRepository.GetRequestForDTO(id);
      if(form is null)
      {
        return this.NotFoundException();
      }

      var requestsDTO = await Mapper.RequestToRequestDTO(form);

      return this.Ok(requestsDTO);
    }
    catch(Exception e)
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
  /// <param name="statusRequestRepository">Репозиторий состояний заявок.</param>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  public RequestController(IRequestRepository requestRepository, IGenericRepository<StatusRequest> statusRequestRepository,
    IStudentRepository studentRepository, ILogger<Request> logger) : base(requestRepository, logger)
  {
    this._requestRepository = requestRepository;
    this._statusRequestRepository = statusRequestRepository;
    this._studentRepository = studentRepository;
  }

  #endregion
}