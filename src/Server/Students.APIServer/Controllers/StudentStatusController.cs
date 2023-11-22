using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentStatusController : GenericAPiController<StudentStatus>
{
    public StudentStatusController(IGenericRepository<StudentStatus> repository, ILogger<StudentStatus> logger) : base(repository, logger)
    {
    }
}