using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер видов приказов.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class KindOrderController : GenericAPiController<KindOrder>
{
  #region Поля и свойства

  private readonly IGenericRepository<KindOrder> _genericRepository;
  private readonly ILogger _logger;

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий типов приказов.</param>
  /// <param name="logger">Логгер.</param>
  public KindOrderController(IGenericRepository<KindOrder> repository, ILogger<KindOrder> logger) : base(repository, logger)
  {
    // на самом деле это нах не нужно. Лучше сделать логгер и репозиторий GenericAPiController видимым для наследника
    _genericRepository = repository;
    _logger = logger;
  }

  #endregion
}