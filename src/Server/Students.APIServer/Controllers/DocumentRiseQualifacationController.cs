using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер Документы повышения квалификации.
/// </summary>
[ApiController]
[Route("controller")]
[ApiVersion("1.0")]
public class DocumentRiseQualifacationController : GenericAPiController<DocumentRiseQualification>
{
  private readonly IGenericRepository<DocumentRiseQualification> _genericRepository;
  private readonly ILogger _logger;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий документов повышения квалификации</param>
  /// <param name="logger">Логгер</param>
  public DocumentRiseQualifacationController(IGenericRepository<DocumentRiseQualification> repository, ILogger<DocumentRiseQualification> logger) : base(repository, logger)
  {
    _genericRepository = repository;
    _logger = logger;
  }
}