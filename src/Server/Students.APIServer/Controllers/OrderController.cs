using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;

namespace Students.APIServer.Controllers;

/// <summary>
/// Контроллер приказов.
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class OrderController : GenericAPiController<Order>
{
  #region Поля и свойства

  private readonly IOrderRepository _orderRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Список приказов с разделением по страницам.
  /// </summary>
  /// <returns>Список DTO приказов.</returns>
  [HttpGet("paged")]
  public async Task<IActionResult> ListAllPagedDTO([FromQuery] Pageable pageable)
  {
    try
    {
      var items = await this._orderRepository.GetOrderDTOByPage(pageable.PageNumber, pageable.PageSize);
      return this.Ok(items);
    }
    catch(Exception e)
    {
      this.Logger.LogError(e, "Error while getting Entities");
      return this.Exception();
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="orderRepository">Репозиторий приказов.</param>
  /// <param name="logger">Логгер.</param>
  public OrderController(IOrderRepository orderRepository,
    ILogger<Order> logger) : base(orderRepository, logger)
  {
    this._orderRepository = orderRepository;
  }

  #endregion
}