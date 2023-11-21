using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentEducationController : GenericAPiController<StudentEducation>
{
    public StudentEducationController(IGenericRepository<StudentEducation> repository, ILogger<StudentEducation> logger) : base(repository, logger)
    {
    }
}