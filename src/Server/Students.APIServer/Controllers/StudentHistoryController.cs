using Asp.Versioning;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.ReferenceModels;
using Students.Models.WebModels;
using System.Diagnostics;

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

  private readonly IGenericRepository<StudentHistory> _genericRepository;
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
    try
    {
      var items = await _genericRepository.Get(x => x.StudentId == studentId);
      return items == null ? NotFoundException() : Ok(items);
    }
    catch (Exception e)
    {
      return Exception(e);
    }
  }

  /// <summary>
  /// Обработка исключения.
  /// </summary>
  /// <param name="e">Исключение.</param>
  /// <returns>Ответ с кодом.</returns>
  private IActionResult Exception(Exception e)
  {
    _logger.LogError(e, "Error while getting Entity by Id");
    return StatusCode(StatusCodes.Status500InternalServerError,
      new DefaultResponse
      {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      });
  }

  /// <summary>
  /// Обработка исключения.
  /// </summary>
  /// <returns>Ответ с кодом.</returns>
  private IActionResult NotFoundException()
  {
    return NotFound(new DefaultResponse
    {
      RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="genericRepository"></param>
  /// <param name="logger"></param>
  public StudentHistoryController(IGenericRepository<StudentHistory> genericRepository, ILogger<StudentHistory> logger) : base(genericRepository, logger)
  {
    _genericRepository = genericRepository;
    _logger = logger;
  }

  #endregion
}

