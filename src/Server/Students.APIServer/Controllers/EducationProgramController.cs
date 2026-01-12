using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers.Interfaces;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.Searches;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер образовательных программ.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class EducationProgramController : GenericAPiController<EducationProgram> , ISearchExecutionService
{
  #region Поля и свойства

  private readonly IEducationProgramRepository _educationProgramRepository;

  #endregion

  #region Методы

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
      var educationProgram = await this._educationProgramRepository.MoveToArchiveOrBack(id);
      return educationProgram is null ? this.NotFoundException() : this.Ok(educationProgram);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while updating Entity");
      return this.Exception();
    }
  }

  /// <inheritdoc />
  [HttpGet("Search")]
  public async Task<IActionResult> SearchAsync([FromQuery] string searchWithoutType)
  {
    try
    {
      var search = SearchSerializer.SearchToTypedSearch<EducationProgram>(searchWithoutType);
      if (search is null)
        return this.BadRequest();

      var items = await this._educationProgramRepository.SearchData(search);
      return this.Ok(items);
    }
    catch (Exception e)
    {
      this.Logger.LogError(e, "Error while searching EducationProgram");
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
  /// <param name="educationProgramRepository">Репозиторий программ обучения.</param>
  /// <param name="logger">Логгер.</param>
  public EducationProgramController(IEducationProgramRepository educationProgramRepository,
    ILogger<EducationProgram> logger) : base(educationProgramRepository, logger)
  {
    this._educationProgramRepository = educationProgramRepository;
  }

  #endregion
}