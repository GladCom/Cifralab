using Asp.Versioning;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.WebModels;
using System.Diagnostics;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер образовательных программ.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationProgramController : GenericAPiController<EducationProgram>
{
  #region Поля и свойства
  private readonly ILogger<EducationProgram> _logger;
  private readonly IEducationProgramRepository _educationProgramRepository;
  private readonly IGenericRepository<EducationProgram> _genericRepository;
  #endregion

  #region Методы
  /// <summary>
  /// Получить список программ обучения по условию.
  /// </summary>
  /// <param name="archive">Условие.</param>
  /// <returns>Список программ обучения.</returns>
  [HttpGet("IsArchive")]
  public async Task<IActionResult> Get(bool archive)
  {
    try
    {
      var educationPrograms = await _genericRepository.Get(
        educationProgram => educationProgram.IsArchive == archive);
      return educationPrograms == null ? NotFoundException() : Ok(educationPrograms);
    }
    catch (Exception e)
    {
      return Exception(e);
    }
  }

  /// <summary>
  /// Поменять статус признака Архив.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  /// <returns>Программа обучения.</returns>
  [HttpPut("MoveToArchiveOrBack")]
  public async Task<IActionResult> MoveToArchiveOrBack(Guid id)
  {
    try
    {
      var educationProgram = await _genericRepository.FindById(id);
      if (educationProgram == null)
      {
        return NotFoundException();
      }
      educationProgram!.IsArchive = !educationProgram.IsArchive;
      await _genericRepository.Update(id, educationProgram);
      return Ok(educationProgram);
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
  /// 
  /// </summary>
  /// <param name="repository">Общий репозиторий.</param>
  /// <param name="educationProgramRepository">Репозиторий программ обучения.</param>
  /// <param name="logger">Логгер.</param>
  public EducationProgramController(IGenericRepository<EducationProgram> repository, IEducationProgramRepository educationProgramRepository, ILogger<EducationProgram> logger) :
    base(repository, logger)
  {
    _logger = logger;
    _educationProgramRepository = educationProgramRepository;
    _genericRepository = repository;
  }
  #endregion
}