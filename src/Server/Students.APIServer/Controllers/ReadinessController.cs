using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.WebModels;

namespace Students.APIServer.Controllers;


/// <summary>
/// ReadinessController.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ReadinessController : ControllerBase
{
  #region Поля и свойства

  private readonly ILogger<LivenessController> _logger;
  private readonly StudentContext _ctx;

  #endregion

  #region Методы

  /// <summary>
  /// Readiness Probe - checks all application dependencies.
  /// </summary>
  /// <returns>Да.</returns>
  [HttpGet(Name = "Readiness Probe")]
  public IActionResult Get()
  {
    try
    {
      return StatusCode(_ctx.Database.CanConnect() ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new DefaultResponse
      {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      });
    }
    catch (Exception e)
    {
      _logger.LogCritical(e.Message);
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Default constructor.
  /// </summary>
  /// <param name="logger">Логгер.</param>
  /// <param name="ctx">Контекст базы данных.</param>
  public ReadinessController(ILogger<LivenessController> logger, StudentContext ctx)
  {
    _logger = logger;
    _ctx = ctx;
  }

  #endregion
}