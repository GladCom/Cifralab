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
    return this.StatusCode(StatusCodes.Status200OK,
      await this._studentRepository.GetStudentsByPage(pageable.PageNumber, pageable.PageSize));
  }

  /// <summary>
  /// Получить студента с заявками и группами(не работает).
  /// </summary>
  /// <param name="studentId">Идентификатор студент.а</param>
  /// <returns>Студент с подгруженными заявками и группами.</returns>
  [HttpPost("GetStudentWithGroupsAndRequests")]
  public async Task<IActionResult> GetStudentWithGroupsAndRequests(Guid studentId)
  {
    try
    {
      var form = await this._studentRepository.GetStudentWithGroupsAndRequests(studentId);
      if(form == null)
      {
        return this.StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
          });
      }

      return this.StatusCode(StatusCodes.Status200OK, form);
    }
    catch(Exception e)
    {
      this._logger.LogError(e, "Error while getting Entity by Id");
      return this.StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
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
    this._studentRepository = studentRepository;
    this._logger = logger;
  }

  #endregion
}
