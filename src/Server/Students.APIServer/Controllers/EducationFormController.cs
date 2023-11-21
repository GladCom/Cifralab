using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationFormController : GenericAPiController<EducationForm>
{
    public EducationFormController(IGenericRepository<EducationForm> repository, ILogger<EducationForm> logger) : base(repository, logger)
    {
    }
}