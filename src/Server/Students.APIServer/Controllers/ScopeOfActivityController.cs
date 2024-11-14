using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер сфер деятельности.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class ScopeOfActivityController : GenericAPiController<ScopeOfActivity>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий сфер деятельности.</param>
  /// <param name="logger">Логгер.</param>
  public ScopeOfActivityController(IGenericRepository<ScopeOfActivity> repository,
    ILogger<ScopeOfActivity> logger) : base(repository, logger)
  {
  }
}