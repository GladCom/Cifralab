using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class GroupController : GenericAPiController<Group>
{
    public GroupController(IGenericRepository<Group> repository, ILogger<Group> logger) : base(repository, logger)
    {
    }
}