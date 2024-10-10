using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер типов финансирования.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class FinancingTypeController : GenericAPiController<FinancingType>
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий типов финансирования.</param>
  /// <param name="logger">Логгер.</param>
  public FinancingTypeController(IGenericRepository<FinancingType> repository, ILogger<FinancingType> logger) : base(
    repository, logger)
  {
  }
}