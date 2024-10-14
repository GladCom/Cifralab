using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
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
  #region Поля и свойства

  IFinancingTypeRepository _financingTypeRepository;
  private readonly ILogger<Group> _logger;

  #endregion

  #region Методы



  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий типов финансирования.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="financingTypeRepository">Репозиторий типов финансирования.</param>
  public FinancingTypeController(IGenericRepository<FinancingType> repository, 
    ILogger<FinancingType> logger, IFinancingTypeRepository financingTypeRepository) : base(repository, logger)
  {
    _financingTypeRepository = financingTypeRepository;
  }

  #endregion
}