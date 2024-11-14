using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер вида программы обучения.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class KindEducationProgramController : GenericAPiController<KindEducationProgram>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий вида программы обучения.</param>
  /// <param name="logger">Логгер.</param>
  public KindEducationProgramController(IGenericRepository<KindEducationProgram> repository, ILogger<KindEducationProgram> logger) 
    : base(repository, logger)
  {
  }
}

