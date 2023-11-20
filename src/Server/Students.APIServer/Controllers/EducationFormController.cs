using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Services.EducationFormService;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// EducationFormController
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationFormController : ControllerBase
{
    private readonly ILogger<LivenessController> logger;
    private readonly EducationFormService educationFormService;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="educationFormService"></param>
    public EducationFormController(ILogger<LivenessController> logger, EducationFormService educationFormService)
    {
        this.logger = logger;
        this.educationFormService = educationFormService;
    }

    /// <summary>
    /// Список форм обучения
    /// </summary>
    /// <returns>Список форм обучения</returns>
    [HttpGet(Name = "List Education Forms")]
    public async Task<IActionResult> ListAll()
    {
        try
        {
            var result = await educationFormService.GetAll();
            return Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while getting Education Forms");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    
    /// <summary>
    /// Получить форму обучения по Id
    /// </summary>
    /// <param name="id">Id формы обучения</param>
    /// <returns>Форма обучения</returns>
    [HttpGet("{id}", Name = "Get Education Form by Id")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var form = await educationFormService.GetFormById(id);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return Ok(form);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while getting Education Form by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    
    /// <summary>
    /// Новая форма обучения
    /// </summary>
    /// <param name="form">Форма обучения</param>
    /// <returns>Форма обучения</returns>
    [HttpPost(Name = "New Education Form")]
    public async Task<IActionResult> Post([FromBody] EducationForm form)
    {
        try
        {
            await educationFormService.Create(form);
            return StatusCode(StatusCodes.Status201Created, form);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while creating new Education Form");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    
    /// <summary>
    /// Обновить форму обучения
    /// </summary>
    /// <param name="id">Id формы обучения</param>
    /// <param name="form">Форма обучения</param>
    /// <returns>Форма обучения</returns>
    [HttpPut("{id}", Name = "Update Education Form")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EducationForm form)
    {
        try
        {
            var oldForm = await educationFormService.Update(id, form);
            if (oldForm == null)
            {
                return NotFound(
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return Ok(form);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while updating Education Form");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }

    /// <summary>
    /// Удалить форму обучения
    /// </summary>
    /// <param name="id">Id формы обучения</param>
    /// <returns>DefaultResponse</returns>
    [HttpDelete("{id}", Name = "Delete Education Form")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var form = await educationFormService.Delete(id);
            if (form == null)
            {
                return NotFound(
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }
            return Ok(
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while deleting Education Form");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
}