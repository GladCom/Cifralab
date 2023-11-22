using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class FEAProgramController : GenericAPiController<FEAProgram>
{
    public FEAProgramController(IGenericRepository<FEAProgram> repository, ILogger<FEAProgram> logger) : base(repository, logger)
    {
    }
}