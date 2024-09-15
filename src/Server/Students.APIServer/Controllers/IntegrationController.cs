using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication.PgOutput.Messages;
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
    private readonly IGenericRepository<Student> _studentRepository;
    private readonly IGenericRepository<EducationProgram> _educationProgramRepository;
    private readonly IGenericRepository<StatusRequest> _statusRequestRepository;
    private readonly IGenericRepository<TypeEducation> _typeEducationRepository;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="logger"></param>
    public IntegrationController(ILogger<IntegrationController> logger, IRequestRepository requestRepository, 
                IGenericRepository<Student> studentRepository, IGenericRepository<EducationProgram> educationProgramRepository,
                IGenericRepository<StatusRequest> statusRequestRepository, IGenericRepository<TypeEducation> typeEducationRepository)
    {
        _logger = logger;
        _requestRepository = requestRepository;
        _studentRepository = studentRepository;
        _educationProgramRepository = educationProgramRepository;
        _statusRequestRepository = statusRequestRepository;
        _typeEducationRepository = typeEducationRepository;
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
            var request = Mapper.WebhookToRequest(form, _educationProgramRepository, _statusRequestRepository);

            var student = _studentRepository.Get().Result.FirstOrDefault(x => x.FullName == form.Name && x.BirthDate.ToString() == form.Birthday && x.Email == form.Email);

            if (student == null)
            {
                if (!_studentRepository.Get().Result.Any(x => x.FullName == form.Name || x.BirthDate.ToString() == form.Birthday || x.Email == form.Email))
                {
                    student = Mapper.WebhookToStudent(form, _studentRepository, _typeEducationRepository);
                    student = await _studentRepository.Create(student);
                }
            }

            request.StudentId = student?.Id;
            request.Student = student;

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