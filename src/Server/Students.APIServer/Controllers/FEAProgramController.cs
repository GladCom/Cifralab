using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер ВЭД программ.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class FEAProgramController : GenericAPiController<FEAProgram>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий ВЭД программ.</param>
  /// <param name="logger">Логгер.</param>
  public FEAProgramController(IGenericRepository<FEAProgram> repository, ILogger<FEAProgram> logger) : base(repository,
    logger)
  {
  }
}