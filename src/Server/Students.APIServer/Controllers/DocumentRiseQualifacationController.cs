using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер Документы повышения квалификации.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class DocumentRiseQualifacationController : GenericAPiController<DocumentRiseQualification>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий документов повышения квалификации.</param>
  /// <param name="logger">Логгер.</param>
  public DocumentRiseQualifacationController(IGenericRepository<DocumentRiseQualification> repository,
    ILogger<DocumentRiseQualification> logger) : base(repository, logger)
  {
  }
}