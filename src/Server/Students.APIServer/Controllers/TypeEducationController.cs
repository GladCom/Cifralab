using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class TypeEducationController : GenericAPiController<TypeEducation>
{
    public TypeEducationController(IGenericRepository<TypeEducation> repository, ILogger<TypeEducation> logger) : base(repository, logger)
    {
    }
}