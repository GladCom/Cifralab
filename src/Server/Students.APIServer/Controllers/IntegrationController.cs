using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.DTO;
using Students.APIServer.Repository.Interfaces;
using Students.Models.WebModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер для интеграции с другими системами.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class IntegrationController : ControllerBase
{
  #region Поля и свойства

  /// <summary>
  /// Логгер контроллера.
  /// </summary>
  private readonly ILogger<IntegrationController> _logger;

  /// <summary>
  /// Репозиторий заявок.
  /// </summary>
  private readonly IRequestRepository _requestRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Создание заявки на обучение по вебхуку.
  /// </summary>
  /// <param name="form">интеграционные данные от минцифры.</param>
  /// <returns>Возвращает статус запроса.</returns>
  [HttpPost("EducationRequest")]
  public async Task<IActionResult> Post([FromBody] RequestWebhook form)
  {
    try
    {
      if(form.Test == "test")
        return this.Ok(form);

      await this._requestRepository.Create(form);
      return this.Ok(form);
    }
    catch(ValidationException e)
    {
      this._logger.LogError(e, "Error while creating new Entity");
      return this.BadRequest(
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
        });
    }
    catch(Exception e)
    {
      this._logger.LogError(e, "Error while creating new Entity");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
        });
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="logger">Логгер контроллера.</param>
  /// <param name="requestRepository">Репозиторий заявок.</param>
  public IntegrationController(IRequestRepository requestRepository, ILogger<IntegrationController> logger)
  {
    this._logger = logger;
    this._requestRepository = requestRepository;
  }

  #endregion
}