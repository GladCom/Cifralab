using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер для интеграции с другими системами
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class IntegrationController : ControllerBase
{
    private readonly ILogger<IntegrationController> _logger;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="logger"></param>
    public IntegrationController(ILogger<IntegrationController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Создание заявки на обчение по вебхуку
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost("EducationRequest")]
    public async Task<IActionResult> Post([FromBody] RequestWebhook form)
    {
        try
        {
            var request = Mapper.WebhookToRequest(form);
            //TODO: Добавить вызов метода репозитоория для создания заявки на обучение
            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating new Entity");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
}