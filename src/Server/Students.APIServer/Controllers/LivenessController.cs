using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.Models.WebModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер живучести сервиса.
/// </summary>
[ApiController]
[Route("[controller]")]
public class LivenessController : ControllerBase
{
  #region Поля и свойства

  private readonly ILogger<LivenessController> _logger;

  #endregion

  #region Методы

  /// <summary>
  /// Тест живучести сервиса - тестирование приложения без зависимостей.
  /// </summary>
  /// <returns>Да.</returns>
  [HttpGet(Name = "Liveness Probe")]
  public IActionResult Get()
  {
    return this.Ok
    (
      new DefaultResponse
      {
        RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
      });
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="logger">Логгер.</param>
  public LivenessController(ILogger<LivenessController> logger)
  {
    this._logger = logger;
  }

  #endregion
}