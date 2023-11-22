using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class FinancingTypeController : GenericAPiController<FinancingType>
{
    public FinancingTypeController(IGenericRepository<FinancingType> repository, ILogger<FinancingType> logger) : base(repository, logger)
    {
    }
}