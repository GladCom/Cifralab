using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using System.Diagnostics;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер ВЭД программ.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class FEAProgramController : GenericAPiController<FEAProgram>
{
  #region Поля и свойства

  /// <summary>
  /// Логгер.
  /// </summary>
  private readonly ILogger<FEAProgram> _logger;

  /// <summary>
  /// Репозиторий ВЭД программ.
  /// </summary>
  private readonly IFEAProgramRepository _feaProgramRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Заполнить БД первоначальным набором справочных данных.
  /// </summary>
  /// <returns>Статус запроса.</returns>
  /// <exception cref="Exception">Исключение возникает, если при записи справочных данных произошла ошибка.</exception>
  [HttpPost("AddSeedData")]
  public async Task<IActionResult> AddSeedData()
  {
    try
    {
      await _feaProgramRepository.AddSeedData();
      return StatusCode(StatusCodes.Status200OK);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Ошибка при заполнении справочника ВЭД первоначальным набором данных.");
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
  /// <param name="repository">Репозиторий ВЭД программ.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="feaProgramRepository">Репозиторий ВЭД программ.</param>
  public FEAProgramController(IGenericRepository<FEAProgram> repository, ILogger<FEAProgram> logger, IFEAProgramRepository feaProgramRepository) : base(repository,
    logger)
  {
    _feaProgramRepository = feaProgramRepository;
    _logger = logger;
  }

  #endregion
}