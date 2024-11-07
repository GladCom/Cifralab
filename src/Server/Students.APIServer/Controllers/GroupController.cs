using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.WebModels;

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
  /// Добавление студентов по заявкам в группу.
  /// </summary>
  /// <param name="requestsList">Список идентификаторов заявок.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификаторы заявок которые не были добавлены.</returns>
  [HttpPost("AddStudentsToGroupByRequest")]
  public async Task<IActionResult> AddStudentsToGroupByRequest(IEnumerable<Guid> requestsList, Guid groupId)
  {
    try
    {
      var badRequests = await this._groupRepository.AddStudentsToGroupByRequest(requestsList, groupId);
      return badRequests is null ? this.NotFoundException() : this.Ok(badRequests);
    }
    catch(Exception e)
    {
      return this.Exception(e);
    }
  }

  /// <summary>
  /// Список групп, в которых состоит студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп.</returns>
  [HttpGet("GetListGroupsOfStudentExists")]
  public async Task<IActionResult> GetListGroupsOfStudentExists(Guid studentId)
  {
    try
    {
      var groups = await this._groupRepository.GetListGroupsOfStudentExists(studentId);
      return groups is null ? this.NotFoundException() : this.Ok(groups);
    }
    catch(Exception e)
    {
      return this.Exception(e);
    }
  }

  /// <summary>
  /// Обработка исключения.
  /// </summary>
  /// <param name="e">Исключение.</param>
  /// <returns>Ответ с кодом.</returns>
  private IActionResult Exception(Exception e)
  {
    this._logger.LogError(e, "Error while getting Entity by Id");
    return this.StatusCode(StatusCodes.Status500InternalServerError,
      new DefaultResponse
      {
        RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
      });
  }

  /// <summary>
  /// Обработка исключения.
  /// </summary>
  /// <returns>Ответ с кодом.</returns>
  private IActionResult NotFoundException()
  {
    return this.NotFound(new DefaultResponse
    {
      RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
    });
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