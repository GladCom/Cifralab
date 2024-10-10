using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.Models;

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
    return StatusCode
    (
      StatusCodes.Status200OK,
      new DefaultResponse
      {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
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
    _logger = logger;
  }

  #endregion
}