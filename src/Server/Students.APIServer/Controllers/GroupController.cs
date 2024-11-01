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
  /// <param name="studentsList">Список студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  [HttpPost("AddStudentsToGroup")]
  public async Task<IActionResult> AddStudentsToGroup(IEnumerable<Student> studentsList, Guid groupId)
  {
    return this.StatusCode(StatusCodes.Status200OK,
      await this._groupRepository.AddStudentsToGroup(studentsList, groupId));
  }

  /// <summary>
  /// Добавить студента в группу.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор студента.</returns>
  [HttpPost("AddStudentToGroup")]
  public async Task<IActionResult> AddStudentToGroup(Guid studentId, Guid groupId)
  {
    return this.StatusCode(StatusCodes.Status200OK,
      await this._groupRepository.AddStudentToGroup(studentId, groupId));
  }

  /// <summary>
  /// Список групп, в которых состоит студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп.</returns>
  [HttpGet("GetListGroupsOfStudentExists")]
  public async Task<IActionResult> GetListGroupsOfStudentExists(Guid studentId)
  {
    return this.StatusCode(StatusCodes.Status200OK,
      await this._groupRepository.GetListGroupsOfStudentExists(studentId));
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
    this._groupRepository = groupRepository;
    this._logger = logger;
  }

  #endregion
}