using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер типов финансирования.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class FinancingTypeController : GenericAPiController<FinancingType>
{
  #region Поля и свойства

  private readonly IFinancingTypeRepository _financingTypeRepository;

  #endregion

  #region Методы

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="logger">Логгер.</param>
  /// <param name="financingTypeRepository">Репозиторий типов финансирования.</param>
  public FinancingTypeController(IFinancingTypeRepository financingTypeRepository,
    ILogger<FinancingType> logger) : base(financingTypeRepository, logger)
  {
    this._financingTypeRepository = financingTypeRepository;
  }

  #endregion
}