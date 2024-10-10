using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер для интеграции с другими системами
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class IntegrationController : ControllerBase
{
  /// <summary>
  /// Логгер контроллера
  /// </summary>
  private readonly ILogger<IntegrationController> _logger;

  /// <summary>
  /// Репозиторий заявок
  /// </summary>
  private readonly IRequestRepository _requestRepository;

  /// <summary>
  /// Репозиторий студентов
  /// </summary>
  private readonly IGenericRepository<Student> _studentRepository;

  /// <summary>
  /// Репозиторий образовательных программ
  /// </summary>
  private readonly IGenericRepository<EducationProgram> _educationProgramRepository;

  /// <summary>
  /// Репозиторий статусов заявок
  /// </summary>
  private readonly IGenericRepository<StatusRequest> _statusRequestRepository;

  /// <summary>
  /// Репозиторий типов образований
  /// </summary>
  private readonly IGenericRepository<TypeEducation> _typeEducationRepository;

  /// <summary>
  /// Конструктор
  /// </summary>
  /// <param name="logger">Логгер контроллера</param>
  /// <param name="requestRepository">Репозиторий заявок</param>
  /// <param name="studentRepository">Репозиторий студентов</param>
  /// <param name="educationProgramRepository">Репозиторий образовательных программ</param>
  /// <param name="statusRequestRepository">Репозиторий статусов заявок</param>
  /// <param name="typeEducationRepository">Репозиторий типов образований</param>
  public IntegrationController(ILogger<IntegrationController> logger, IRequestRepository requestRepository,
    IGenericRepository<Student> studentRepository, IGenericRepository<EducationProgram> educationProgramRepository,
    IGenericRepository<StatusRequest> statusRequestRepository,
    IGenericRepository<TypeEducation> typeEducationRepository)
  {
    _logger = logger;
    _requestRepository = requestRepository;
    _studentRepository = studentRepository;
    _educationProgramRepository = educationProgramRepository;
    _statusRequestRepository = statusRequestRepository;
    _typeEducationRepository = typeEducationRepository;
  }

  /// <summary>
  /// Создание заявки на обучение по вебхуку
  /// </summary>
  /// <param name="form">интеграционные данные от минцифры</param>
  /// <returns>Возвращает статус запроса</returns>
  [HttpPost("EducationRequest")]
  public async Task<IActionResult> Post([FromBody] RequestWebhook form)
  {
    try
    {
      var request = Mapper.WebhookToRequest(form, _educationProgramRepository, _statusRequestRepository);

      var student = _studentRepository.Get().Result.FirstOrDefault(x =>
        x.FullName == form.Name && x.BirthDate.ToString() == form.Birthday && x.Email == form.Email);

      if (student == null)
      {
        if (!_studentRepository.Get().Result.Any(x =>
              x.FullName == form.Name || x.BirthDate.ToString() == form.Birthday || x.Email == form.Email))
        {
          student = Mapper.WebhookToStudent(form, _studentRepository, _typeEducationRepository);
          student = await _studentRepository.Create(student);
        }
      }

      request.StudentId = student?.Id;
      request.Student = student;

      var result = await _requestRepository.Create(request);
      return StatusCode(StatusCodes.Status200OK, form);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error while creating new Entity");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

}