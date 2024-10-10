using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер групп студентов.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentGroupController : GenericAPiController<GroupStudent>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository"> Репозиторий группы со студентами.</param>
  /// <param name="logger">Логгер.</param>
  public StudentGroupController(IGenericRepository<GroupStudent> repository, ILogger<GroupStudent> logger) : base(
    repository, logger)
  {
  }
}