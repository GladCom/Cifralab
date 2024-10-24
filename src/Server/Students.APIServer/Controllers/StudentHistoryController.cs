using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер истории стуента.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class StudentHistoryController : GenericAPiController<StudentHistory>
{
  #region Поля и свойства

  private readonly IStudentHistoryRepository _studentHistoryRepository;
  private readonly ILogger _logger;

  #endregion

  #region Методы

  /// <summary>
  /// Список истории изменений студента.
  /// </summary>
  /// <param name="studentId">Id студента.</param>
  /// <returns>Список изменений.</returns>
  [HttpGet("GetListChanges/{studentId}")]
  public async Task<IActionResult> GetListChanges(Guid studentId)
  {
    var items = await _studentHistoryRepository.GetListChangesByStudentIdAsync(studentId);
    return StatusCode(StatusCodes.Status200OK, items);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="studentHistoryRepository"></param>
  /// <param name="logger"></param>
  public StudentHistoryController(IStudentHistoryRepository studentHistoryRepository, ILogger<StudentHistory> logger) : base(studentHistoryRepository, logger)
  {
    _studentHistoryRepository = studentHistoryRepository;
    _logger = logger;
  }

  #endregion
}

