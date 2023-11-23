using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentController : GenericAPiController<Student>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<Student> _logger;
    public StudentController(IGenericRepository<Student> repository, ILogger<Student> logger, IStudentRepository studentRepository) : base(repository, logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    /// <summary>
    /// Список объектов с разделением по страницам
    /// </summary>
    /// <returns></returns>
    [HttpGet("paged")]
    public async Task<IActionResult> ListAllPaged([FromQuery] Pageable pageable)
    {
        return StatusCode(StatusCodes.Status200OK, await _studentRepository.GetStudentsByPage(pageable.PageNumber, pageable.PageSize));
    }
    
    // Отключение базового метода ListAll
    [ApiExplorerSettings(IgnoreApi=true)]
    public override Task<IActionResult>ListAll()
    {
        return null;
    }

    /// <summary>
    /// Получить объект по Id с включением связанных объектов
    /// </summary>
    /// <param name="id">Id Объекта</param>
    /// <returns>Объект</returns>
    public override async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var form = await _studentRepository.FindById(id);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
}
