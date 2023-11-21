using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationProgramController : GenericAPiController<EducationProgram>
{
    public EducationProgramController(IGenericRepository<EducationProgram> repository, ILogger<EducationProgram> logger) : base(repository, logger)
    {
    }
}