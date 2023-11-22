using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentDocumentController : GenericAPiController<StudentDocument>
{
    public StudentDocumentController(IGenericRepository<StudentDocument> repository, ILogger<StudentDocument> logger) : base(repository, logger)
    {
    }
}