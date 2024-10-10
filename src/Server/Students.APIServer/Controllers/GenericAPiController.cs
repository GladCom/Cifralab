using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Абстрактный generic контроллер
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class GenericAPiController<TEntity> : ControllerBase where TEntity : class
{
  private readonly IGenericRepository<TEntity> _rep;
  private readonly ILogger<TEntity> _logger;

  /// <summary>
  /// Default constructor
  /// </summary>
  /// <param name="repository"></param>
  /// <param name="logger"></param>
  protected GenericAPiController(IGenericRepository<TEntity> repository, ILogger<TEntity> logger)
  {
    _rep = repository;
    _logger = logger;
  }

  /// <summary>
  /// Список всех объектов
  /// </summary>
  /// <returns>Список объектов</returns>
  [HttpGet]
  public virtual async Task<IActionResult> ListAll()
  {
    try
    {
      return StatusCode(StatusCodes.Status200OK,
        await _rep.Get());
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error while getting Entity");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

  /// <summary>
  /// Получить объект по Id
  /// </summary>
  /// <param name="id">Id Объекта</param>
  /// <returns>Объект</returns>
  [HttpGet("{id}")]
  public virtual async Task<IActionResult> Get(Guid id)
  {
    try
    {
      var form = await _rep.FindById(id);
      if (form == null)
      {
        return StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
          });
      }

      return StatusCode(StatusCodes.Status200OK, form);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error while getting Entity by Id");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

  /// <summary>
  /// Новый объект
  /// </summary>
  /// <param name="form">Объект</param>
  /// <returns>Объект</returns>
  [HttpPost]
  public virtual async Task<IActionResult> Post([FromBody] TEntity form)
  {
    try
    {
      await _rep.Create(form);
      return StatusCode(StatusCodes.Status201Created, form);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error while creating new Entity");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

  /// <summary>
  /// Обновить объект
  /// </summary>
  /// <param name="id">Id объекта</param>
  /// <param name="form">объект</param>
  /// <returns>объект</returns>
  [HttpPut("{id}")]
  public virtual async Task<IActionResult> Put(Guid id, [FromBody] TEntity form)
  {
    try
    {
      var result = await _rep.Update(id, form);
      if (result == null)
      {
        return StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
          });
      }

      return StatusCode(StatusCodes.Status200OK, form);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error while updating Entity");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }

  /// <summary>
  /// Удалить объект
  /// </summary>
  /// <param name="id">Id объекта</param>
  /// <returns>DefaultResponse</returns>
  [HttpDelete("{id}")]
  public virtual async Task<IActionResult> Delete(Guid id)
  {
    try
    {
      var form = await _rep.FindById(id);
      if (form == null)
      {
        return StatusCode(StatusCodes.Status404NotFound,
          new DefaultResponse
          {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
          });
      }

      await _rep.Remove(form);
      return StatusCode(StatusCodes.Status200OK,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error while deleting Entity");
      return StatusCode(StatusCodes.Status500InternalServerError,
        new DefaultResponse
        {
          RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
  }
}