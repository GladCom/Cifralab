using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер формы образования
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationFormController : GenericAPiController<EducationForm>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="repository">Репозиторий форм образований</param>
    /// <param name="logger">Логгер</param>
    public EducationFormController(IGenericRepository<EducationForm> repository, ILogger<EducationForm> logger) : base(repository, logger)
    {
    }
}