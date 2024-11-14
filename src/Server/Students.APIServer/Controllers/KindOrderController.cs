using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.ReferenceModels;

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

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий типов приказов.</param>
  /// <param name="logger">Логгер.</param>
  public KindOrderController(IGenericRepository<KindOrder> repository,
    ILogger<KindOrder> logger) : base(repository, logger)
  {
  }

  #endregion
}