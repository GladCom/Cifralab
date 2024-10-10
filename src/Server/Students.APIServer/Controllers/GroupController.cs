using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер группы.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class GroupController : GenericAPiController<Group>
{
  #region Поля и свойства

  private readonly IGroupRepository _groupRepository;
  private readonly ILogger<Group> _logger;

  #endregion

  #region Методы

  /// <summary>
  /// Добавление студентов в группу.
  /// </summary>
  /// <param name="studentList">Список студентов.</param>
  /// <param name="groupID">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  [HttpPost("AddStudentToGroup")]
  public async Task<IActionResult> AddStudentToGroup(IEnumerable<Student> studentList, Guid groupID)
  {
    return StatusCode(StatusCodes.Status200OK,
      await _groupRepository.AddStudentsInGroup(studentList, groupID));
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="groupRepository">Репозиторий групп.</param>
  /// <param name="logger">Логгер.</param>
  public GroupController(IGroupRepository groupRepository, ILogger<Group> logger) : base(groupRepository, logger)
  {
    _groupRepository = groupRepository;
    _logger = logger;
  }

  #endregion
}