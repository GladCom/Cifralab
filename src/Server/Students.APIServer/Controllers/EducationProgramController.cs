using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

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
      return this.Ok(educationPrograms);
    }
    catch(Exception e)
    {
      this._logger.LogError(e, "Error while getting Entities");
      return this.Exception();
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
      if(educationProgram is null)
      {
        return this.NotFoundException();
      }
      educationProgram.IsArchive = !educationProgram.IsArchive;
      await this._genericRepository.Update(id, educationProgram);
      return this.Ok(educationProgram);
    }
    catch(Exception e)
    {
      this._logger.LogError(e, "Error while updating Entity");
      return this.Exception();
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
      this._logger.LogError(e, "Error while getting Entities");
      return this.Exception();
    }
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