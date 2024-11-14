using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

//был создан как самостоятельный элемент, но в последних требованиях от аналитиков эти состояния перешли в состояния заявки
/// <summary>
/// Контроллер статусов студента.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentStatusController : GenericAPiController<StudentStatus>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий студентов.</param>
  /// <param name="logger">Логгер.</param>
  public StudentStatusController(IGenericRepository<StudentStatus> repository,
    ILogger<StudentStatus> logger) : base(repository, logger)
  {
  }
}