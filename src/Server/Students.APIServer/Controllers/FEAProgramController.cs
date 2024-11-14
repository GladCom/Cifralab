using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

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
  /// <param name="logger">Логгер.</param>
  /// <param name="feaProgramRepository">Репозиторий ВЭД программ.</param>
  public FEAProgramController(IFEAProgramRepository feaProgramRepository,
    ILogger<FEAProgram> logger) : base(feaProgramRepository, logger)
  {
    this._feaProgramRepository = feaProgramRepository;
  }

  #endregion
}