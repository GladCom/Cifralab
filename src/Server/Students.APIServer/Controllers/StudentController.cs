using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.WebModels;

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
  private readonly ILogger<Student> _logger;

  #endregion

  #region Методы

  /// <summary>
  /// Список студентов с разделением по страницам (кажется это можно вынести в абстрактный класс).
  /// </summary>
  [HttpGet("paged")]
  public async Task<IActionResult> ListAllPaged([FromQuery] Pageable pageable)
  {
    return StatusCode(StatusCodes.Status200OK,
      await _studentRepository.GetStudentsByPage(pageable.PageNumber, pageable.PageSize));
  }

  /// <summary>
  /// Список групп, в которых состоит студент.
  /// </summary>
  /// <param name="student">Идентификатор студента.</param>
  /// <returns>Список групп.</returns>
  [HttpGet("GetListGroupsOfStudentExists")]
  public async Task<IActionResult> GetListGroupsOfStudentExists(Guid student)
  {
    return StatusCode(StatusCodes.Status200OK,
      await _studentRepository.GetListGroupsOfStudentExists(student));
  }

  /// <summary>
  /// Добавить студента в группу.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="groupID">Идентификатор группы.</param>
  /// <returns>Идентификатор студента.</returns>
  [HttpPost("AddStudentToGroup")]
  public async Task<IActionResult> AddStudentToGroup(Guid studentId, Guid groupID)
  {
    return StatusCode(StatusCodes.Status200OK,
      await _studentRepository.AddStudentToGroup(studentId, groupID));
  }

  /// <summary>
  /// Получить студента.
  /// </summary>
  /// <param name="id">Идентификатор студент.а</param>
  /// <returns>Состояние запроса + студент.</returns>
  public override async Task<IActionResult> Get(Guid id)
  {
    try
    {
      var form = await _studentRepository.FindById(id);
      if(form == null)
      {
        return StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
          });
      }

      return StatusCode(StatusCodes.Status200OK, form);
    }
    catch(Exception e)
    {
      _logger.LogError(e, "Error while getting Entity by Id");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий студентов.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  public StudentController(IGenericRepository<Student> repository, ILogger<Student> logger,
    IStudentRepository studentRepository) : base(repository, logger)
  {
    _studentRepository = studentRepository;
    _logger = logger;
  }

  #endregion
}
