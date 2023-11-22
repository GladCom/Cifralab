using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationTypeController : GenericAPiController<EducationType>
{
    public EducationTypeController(IGenericRepository<EducationType> repository, ILogger<EducationType> logger) : base(repository, logger)
    {
    }
}