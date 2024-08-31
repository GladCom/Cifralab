using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class KindDocumentRiseQualificationController : GenericAPiController<KindDocumentRiseQualification>
{
    public KindDocumentRiseQualificationController(IGenericRepository<KindDocumentRiseQualification> repository, ILogger<KindDocumentRiseQualification> logger) : base(repository, logger)
    {
    }
}