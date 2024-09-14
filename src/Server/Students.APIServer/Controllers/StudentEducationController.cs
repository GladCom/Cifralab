using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentEducationController : GenericAPiController<TypeEducation>
{
    public StudentEducationController(IGenericRepository<TypeEducation> repository, ILogger<TypeEducation> logger) : base(repository, logger)
    {
    }
}