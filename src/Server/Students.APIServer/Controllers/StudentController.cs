using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер студентов.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentController : GenericAPiController<Student>
{
  #region Поля и свойства

  private readonly IStudentRepository _studentRepository;

  #endregion

  #region Методы

  //(кажется это можно вынести в абстрактный класс)
  /// <summary>
  /// Список студентов с разделением по страницам.
  /// </summary>
  [HttpGet("paged")]
  public async Task<IActionResult> ListAllPaged([FromQuery] Pageable pageable)
  {
    try
    {
      var items = await this._studentRepository.GetStudentsByPage(pageable.PageNumber, pageable.PageSize);
      return this.Ok(items);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entities");
      return this.Exception();
    }
  }

  /// <summary>
  /// Получить студента с заявками и группами.
  /// </summary>
  /// <param name="studentId">Идентификатор студент.а</param>
  /// <returns>Студент с подгруженными заявками и группами.</returns>
  [HttpPost("GetStudentWithGroupsAndRequests")]
  public async Task<IActionResult> GetStudentWithGroupsAndRequests(Guid studentId)
  {
    try
    {
      var form = await this._studentRepository.GetStudentWithGroupsAndRequests(studentId);
      return form is null ? this.NotFoundException() : this.Ok(form);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entity by Id");
      return this.Exception();
    }
  }
  
  [HttpPost("EnrollStudentInGroup")]
  public async Task<IActionResult> EnrollStudentInGroup(Guid requestId, Guid groupId)
  {
    if (requestId == Guid.Empty || groupId == Guid.Empty)
      return this.BadRequest("Request ID or group ID is empty");
    try
    {
      var student = await this._studentRepository.EnrollStudentInGroup(requestId, groupId);
      return this.Ok(student);
    }
    catch (ArgumentException argEx)
    {
      return this.BadRequest(argEx.Message);
    }
    catch (InvalidOperationException ioEx)
    {
      return this.Conflict(ioEx.Message);
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="logger">Логгер.</param>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  public StudentController(IStudentRepository studentRepository,
    ILogger<Student> logger) : base(studentRepository, logger)
  {
    this._studentRepository = studentRepository;
  }

  #endregion
}
