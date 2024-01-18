using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
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
    private readonly IRequestRepository _requestRepository;
    private readonly IGenericRepository<StudentEducation> _studentEducationRepository;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="logger"></param>
    public IntegrationController(ILogger<IntegrationController> logger, IRequestRepository requestRepository, IGenericRepository<StudentEducation> studentEducationRepository)
    {
        _logger = logger;
        _requestRepository = requestRepository;
        _studentEducationRepository = studentEducationRepository;
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
            var request = Mapper.WebhookToRequest(form, _studentEducationRepository);
            var result = await _requestRepository.Create(request);
            return StatusCode(StatusCodes.Status200OK, form);
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