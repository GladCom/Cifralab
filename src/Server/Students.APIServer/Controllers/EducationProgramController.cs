using System.Diagnostics;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.WebModels;

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
      var educationPrograms = await this._genericRepository.Get(
        educationProgram => educationProgram.IsArchive == archive);
      return educationPrograms.Any() ? this.Ok(educationPrograms) : this.NotFoundException();
    }
    catch(Exception e)
    {
      return this.Exception(e);
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
      var educationProgram = await this._genericRepository.FindById(id);
      if(educationProgram == null)
      {
        return this.NotFoundException();
      }
      educationProgram!.IsArchive = !educationProgram.IsArchive;
      await this._genericRepository.Update(id, educationProgram);
      return this.Ok(educationProgram);
    }
    catch(Exception e)
    {
      return this.Exception(e);
    }
  }

  /// <summary>
  /// Список с программами обучения, на которых учился студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список программ обучения.</returns>
  [HttpGet("GetListEducationProgramsOfStudentExists")]
  public async Task<IActionResult> GetListEducationProgramsOfStudentExists(Guid studentId)
  {
    try
    {
      var educationPrograms = await this._educationProgramRepository.GetListEducationProgramsOfStudentExists(studentId);
      return educationPrograms is null ? this.NotFoundException() : this.Ok(educationPrograms);
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
  /// 
  /// </summary>
  /// <param name="repository">Общий репозиторий.</param>
  /// <param name="educationProgramRepository">Репозиторий программ обучения.</param>
  /// <param name="logger">Логгер.</param>
  public EducationProgramController(IGenericRepository<EducationProgram> repository, IEducationProgramRepository educationProgramRepository, ILogger<EducationProgram> logger) :
    base(repository, logger)
  {
    this._logger = logger;
    this._educationProgramRepository = educationProgramRepository;
    this._genericRepository = repository;
  }

  #endregion
}