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
	private readonly IGroupRepository _groupRepository;
	private readonly ILogger<Group> _logger;
	public GroupController(IGenericRepository<Group> repository, ILogger<Group> logger, IGroupRepository groupRepository) : base(repository, logger) {
		_groupRepository = groupRepository;
		_logger = logger;
	}
	/// <summary>
	/// Добавление студентов в группу
	/// </summary>
	/// <param name="studentList"></param>
	/// <param name="groupID"></param>
	/// <returns></returns>
	[HttpPost("AddStudentToGroup")]
	public async Task<IActionResult> AddStudentToGroup(IEnumerable<Student> studentList, Guid groupID)
	{
		return StatusCode(StatusCodes.Status200OK,
			await _groupRepository.AddStudentsInGroup(studentList, groupID));
	}
}