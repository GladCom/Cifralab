using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class ScopeOfActivityController : GenericAPiController<ScopeOfActivity>
{
    public ScopeOfActivityController(IGenericRepository<ScopeOfActivity> repository, ILogger<ScopeOfActivity> logger) : base(repository, logger)
    {
    }
}