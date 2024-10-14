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
  #region Поля и свойства

  /// <summary>
  /// Логгер.
  /// </summary>
  private readonly ILogger<FEAProgram> _logger;

  /// <summary>
  /// Репозиторий ВЭД программ.
  /// </summary>
  private readonly IFEAProgramRepository _feaProgramRepository;

  #endregion

  #region Методы



  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий ВЭД программ.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="feaProgramRepository">Репозиторий ВЭД программ.</param>
  public FEAProgramController(IGenericRepository<FEAProgram> repository, ILogger<FEAProgram> logger, IFEAProgramRepository feaProgramRepository) : base(repository,
    logger)
  {
    _feaProgramRepository = feaProgramRepository;
    _logger = logger;
  }

  #endregion
}