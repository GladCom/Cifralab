using System.ComponentModel.DataAnnotations;
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
/// Контроллер для интеграции с другими системами.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class IntegrationController : ControllerBase
{
  #region Поля и свойства

  /// <summary>
  /// Логгер контроллера.
  /// </summary>
  private readonly ILogger<IntegrationController> _logger;

  /// <summary>
  /// Репозиторий заявок.
  /// </summary>
  private readonly IRequestRepository _requestRepository;

  /// <summary>
  /// Репозиторий студентов.
  /// </summary>
  private readonly IStudentRepository _studentRepository;

  /// <summary>
  /// Репозиторий образовательных программ.
  /// </summary>
  private readonly IEducationProgramRepository _educationProgramRepository;

  /// <summary>
  /// Репозиторий статусов заявок.
  /// </summary>
  private readonly IGenericRepository<StatusRequest> _statusRequestRepository;

  /// <summary>
  /// Репозиторий типов образований.
  /// </summary>
  private readonly IGenericRepository<TypeEducation> _typeEducationRepository;

  /// <summary>
  /// Репозиторий сфер деятельности.
  /// </summary>
  private readonly IGenericRepository<ScopeOfActivity> _scopeOfActivityRepository;

  /// <summary>
  /// Репозиторий неподтверждённых студентов.
  /// </summary>
  private readonly IGenericRepository<PhantomStudent> _fantomStudentRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Создание заявки на обучение по вебхуку.
  /// </summary>
  /// <param name="form">интеграционные данные от минцифры.</param>
  /// <returns>Возвращает статус запроса.</returns>
  [HttpPost("EducationRequest")]
  public async Task<IActionResult> Post([FromBody] RequestWebhook form)
  {
    try
    {
      var request = await Mapper.WebhookToRequest(form, this._educationProgramRepository, this._statusRequestRepository);

      var student = await this._studentRepository.GetOne(x =>
        x.FullName == form.Name && x.BirthDate.ToString() == form.Birthday && x.Email == form.Email);

      if(student is null)
      {
        request.IsAlreadyStudied = false;
        if(await this._studentRepository.GetOne(x =>
              x.FullName == form.Name || x.BirthDate.ToString() == form.Birthday || x.Email == form.Email) is null)
        {
          var fantomStudent = await Mapper.WebhookToStudent(form, this._typeEducationRepository, this._scopeOfActivityRepository);
          fantomStudent = await this._fantomStudentRepository.Create(fantomStudent);
          request.PhantomStudentId = fantomStudent.Id;
        }
      }
      else
      {
        request.StudentId = student.Id;
      }

      await this._requestRepository.Create(request);
      return this.Ok(form);
    }
    catch(ValidationException e)
    {
      this._logger.LogError(e, "Error while creating new Entity");
      return this.BadRequest(
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
        });
    }
    catch(Exception e)
    {
      this._logger.LogError(e, "Error while creating new Entity");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
        });
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="fantomStudentRepository">Репозиторий неподтверждённых студентов.</param>
  /// <param name="logger">Логгер контроллера.</param>
  /// <param name="requestRepository">Репозиторий заявок.</param>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  /// <param name="educationProgramRepository">Репозиторий образовательных программ.</param>
  /// <param name="statusRequestRepository">Репозиторий статусов заявок.</param>
  /// <param name="typeEducationRepository">Репозиторий типов образований.</param>
  /// <param name="scopeOfActivityRepository">Репозиторий сфер деятельности.</param>
  public IntegrationController(IRequestRepository requestRepository, IStudentRepository studentRepository,
    IEducationProgramRepository educationProgramRepository, IGenericRepository<StatusRequest> statusRequestRepository,
    IGenericRepository<TypeEducation> typeEducationRepository, IGenericRepository<ScopeOfActivity> scopeOfActivityRepository,
    IGenericRepository<PhantomStudent> fantomStudentRepository, ILogger<IntegrationController> logger)
  {
    this._logger = logger;
    this._requestRepository = requestRepository;
    this._studentRepository = studentRepository;
    this._educationProgramRepository = educationProgramRepository;
    this._statusRequestRepository = statusRequestRepository;
    this._typeEducationRepository = typeEducationRepository;
    this._scopeOfActivityRepository = scopeOfActivityRepository;
    this._fantomStudentRepository = fantomStudentRepository;
  }

  #endregion
}