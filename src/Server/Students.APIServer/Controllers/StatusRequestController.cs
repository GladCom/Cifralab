using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StatusRequestController : GenericAPiController<StatusRequest>
{
    public StatusRequestController(IGenericRepository<StatusRequest> repository, ILogger<StatusRequest> logger) : base(repository, logger)
    {
    }
}
