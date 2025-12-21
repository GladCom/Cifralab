using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository.Interfaces;
using Students.Models.Filters;
using Students.Models.Searches;
using Students.Models.WebModels;

namespace Students.APIServer.Controllers;

/// <summary>
/// Абстрактный generic контроллер.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class GenericAPiController<TEntity> : ControllerBase where TEntity : class
{
  #region Поля и свойства

  private readonly IGenericRepository<TEntity> _rep;

  /// <summary>
  /// Логгер.
  /// </summary>
  protected ILogger<TEntity> Logger { get; }

  #endregion

  #region Методы

  /// <summary>
  /// Список всех объектов.
  /// </summary>
  /// <returns>Список объектов</returns>
  [HttpGet]
  public virtual async Task<IActionResult> ListAll()
  {
    try
    {
      return this.Ok(await this._rep.Get());
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entities");
      return this.Exception();
    }
  }

  /// <summary>
  /// Фильтрация.
  /// </summary>
  /// <returns>Список объектов.</returns>
  [HttpGet("Filter")]
  public async Task<IActionResult> ListFiltered([FromQuery] string filterWithoutType)
  {
    try
    {
      var filter = FiltersSerializer.FilterToTypedFilter<TEntity>(filterWithoutType);
      if(filter is null)
        return this.BadRequest();
      return this.Ok(await this._rep.GetFiltered(filter));
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entities");
      return this.Exception();
    }
  }

  /// <summary>
  /// Поиск.
  /// </summary>
  /// <param name="searchWithoutType">JSON-строка с параметрами поиска.</param>
  /// <returns>Список найденных объектов.</returns>
  [HttpGet("Search")]
  public async Task<IActionResult> ListSearched([FromQuery] string searchWithoutType)
  {
    try
    {
      var search = SearchSerializer.SearchToTypedSearch<TEntity>(searchWithoutType);
      if (search is null)
        return this.BadRequest();

      return this.Ok(await this._rep.GetSearched(search));
    }
    catch (Exception e)
    {
      this.Logger.LogError(e, "Error while searching Entities");
      return this.Exception();
    }
  }


  /// <summary>
  /// Получить объект по Id.
  /// </summary>
  /// <param name="id">Id Объекта.</param>
  /// <returns>Объект.</returns>
  [HttpGet("{id}")]
  public virtual async Task<IActionResult> Get(Guid id)
  {
    try
    {
      var form = await this._rep.FindById(id);
      return form is null ? this.NotFoundException() : this.Ok(form);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entity by Id");
      return this.Exception();
    }
  }

  /// <summary>
  /// Новый объект.
  /// </summary>
  /// <param name="form">Объект.</param>
  /// <returns>Объект.</returns>
  [HttpPost]
  public virtual async Task<IActionResult> Post([FromBody] TEntity form)
  {
    try
    {
      await this._rep.Create(form);
      return this.StatusCode(StatusCodes.Status201Created, form);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while creating new Entity");
      return this.Exception();
    }
  }

  /// <summary>
  /// Обновить объект.
  /// </summary>
  /// <param name="id">Id объекта.</param>
  /// <param name="form">Объект.</param>
  /// <returns>Объект.</returns>
  [HttpPut("{id}")]
  public virtual async Task<IActionResult> Put(Guid id, [FromBody] TEntity form)
  {
    try
    {
      var result = await this._rep.Update(id, form);
      return result is null ? this.NotFoundException() : this.Ok(form);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while updating Entity");
      return this.Exception();
    }
  }

  /// <summary>
  /// Удалить объект.
  /// </summary>
  /// <param name="id">Id объекта.</param>
  /// <returns>DefaultResponse.</returns>
  [HttpDelete("{id}")]
  public virtual async Task<IActionResult> Delete(Guid id)
  {
    try
    {
      var form = await this._rep.FindById(id);
      if(form is null)
      {
        return this.NotFoundException();
      }

      await this._rep.Remove(form);
      return this.Ok(this.GetDefaultResponse());
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while deleting Entity");
      return this.Exception();
    }
  }

  /// <summary>
  /// Обработка исключения.
  /// </summary>
  /// <returns>Ответ с кодом.</returns>
  protected IActionResult Exception()
  {
    return this.StatusCode(StatusCodes.Status500InternalServerError,
      this.GetDefaultResponse());
  }

  /// <summary>
  /// Обработка исключения.
  /// </summary>
  /// <returns>Ответ с кодом.</returns>
  protected IActionResult NotFoundException()
  {
    return this.NotFound(this.GetDefaultResponse());
  }

  private DefaultResponse GetDefaultResponse()
  {
    return new DefaultResponse
    {
      RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
    };
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="repository">Репозиторий.</param>
  /// <param name="logger">Логгер.</param>
  protected GenericAPiController(IGenericRepository<TEntity> repository, ILogger<TEntity> logger)
  {
    this._rep = repository;
    this.Logger = logger;
  }

  #endregion
}