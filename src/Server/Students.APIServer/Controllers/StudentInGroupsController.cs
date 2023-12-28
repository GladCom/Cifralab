using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class StudentInGroupsController : GenericAPiController<GroupStudent>
	{
		public StudentInGroupsController(IGenericRepository<GroupStudent> repository, ILogger<GroupStudent> logger) : base(repository, logger)
		{
		}
	}
}
