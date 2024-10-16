using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер видов документов повышения квалификации.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class KindDocumentRiseQualificationController : GenericAPiController<KindDocumentRiseQualification>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий видов документов повышения квалификации.</param>
  /// <param name="logger">Логгер.</param>
  public KindDocumentRiseQualificationController(IGenericRepository<KindDocumentRiseQualification> repository,
    ILogger<KindDocumentRiseQualification> logger) : base(repository, logger)
  {
  }
}