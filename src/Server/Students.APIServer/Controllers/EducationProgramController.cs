using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер образовательных программ
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationProgramController : GenericAPiController<EducationProgram>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="repository">Репозиторий образовательных программ</param>
    /// <param name="logger">Логгер</param>
    public EducationProgramController(IGenericRepository<EducationProgram> repository, ILogger<EducationProgram> logger) : base(repository, logger)
    {
    }
}