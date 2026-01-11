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

  #endregion

  #region Методы

  /// <summary>
  /// Добавление студентов по заявкам в группу.
  /// </summary>
  /// <param name="requestsList">Список идентификаторов заявок.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификаторы заявок которые не были добавлены.</returns>
  [HttpPost("AddStudentsToGroupByRequest")]
  public async Task<IActionResult> AddStudentsToGroupByRequest(List<Guid> requestsList, Guid groupId)
  {
    try
    {
      var badRequests = await this._groupRepository.AddStudentsToGroupByRequest(requestsList, groupId);
      return badRequests is null ? this.NotFoundException() : this.Ok(badRequests);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while creating Entity");
      return this.Exception();
    }
  }

  /// <summary>
  /// Удаление студентов из группы.
  /// </summary>
  /// <param name="studentList">Список идентификаторов студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  [HttpPost("RemoveStudentsFromGroup")]
  public async Task<IActionResult> RemoveStudentsFromGroupByRequest(List<Guid> studentList, Guid groupId)
  {
    try
    {
      var form = await this._groupRepository.RemoveStudentsFromGroup(studentList, groupId);
      return form is null ? this.NotFoundException() : this.Ok(form);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while deleting Entities");
      return this.Exception();
    }
  }

  #endregion

  #region Базовый класс

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="groupRepository">Репозиторий групп.</param>
  /// <param name="logger">Логгер.</param>
  public GroupController(IGroupRepository groupRepository,
    ILogger<Group> logger) : base(groupRepository, logger)
  {
    this._groupRepository = groupRepository;
  }

  #endregion
}