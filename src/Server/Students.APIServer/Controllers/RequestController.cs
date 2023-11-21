using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class RequestController : GenericAPiController<Request>
{
    public RequestController(IGenericRepository<Request> repository, ILogger<Request> logger) : base(repository, logger)
    {
    }
}