using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class StudentInGroupsController : GenericAPiController<StudentInGroup>
	{
		public StudentInGroupsController(IGenericRepository<StudentInGroup> repository, ILogger<StudentInGroup> logger) : base(repository, logger)
		{
		}
	}
}
