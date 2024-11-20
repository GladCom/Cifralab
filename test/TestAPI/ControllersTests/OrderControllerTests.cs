using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI.ControllersTests;

[TestFixture]
public class OrderControllerTests
{
  private StudentContext _studentContext;
  private OrderController _orderController;

  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("9dfff5af-8e87-450f-9d5b-d987739ee712"),
    Guid.Parse("581493f2-c2ae-41a0-b031-c22c0727d232"),
    Guid.Parse("a6a9e757-f7fb-4059-8bb9-a3b76d8e0618")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    var orderRepository = new OrderRepository(this._studentContext);
    this._orderController = new OrderController(orderRepository, new TestLogger<Order>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.Orders.RemoveRange(this._studentContext.Set<Order>());
    this._studentContext.SaveChangesAsync();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task ListAllPagedDTO_NullListRequest_Ok()
  {
    //Arrange
    var pageable = new Pageable();

    // Act
    var result = await this._orderController.ListAllPagedDTO(pageable);

    // Assert
    var okResult = result as ObjectResult;
    var listOrder = okResult?.Value as PagedPage<OrderDTO>;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(listOrder, Is.Not.Null);
      Assert.That(listOrder?.TotalCount, Is.EqualTo(0));
    });
  }

  [Test]
  public async Task ListAllPagedDTO_Ok()
  {
    //Arrange
    var pageable = new Pageable();
    var newOrder = GenerateNewOrder(this._guids[0]);
    await this._orderController.Post(newOrder);
    var newOrder2 = GenerateNewOrder(this._guids[1]);
    await this._orderController.Post(newOrder2);

    // Act
    var result = await this._orderController.ListAllPagedDTO(pageable);

    // Assert
    var okResult = result as ObjectResult;
    var listOrder = okResult?.Value as PagedPage<OrderDTO>;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(listOrder, Is.Not.Null);
      Assert.That(listOrder?.TotalCount, Is.EqualTo(2));
    });
  }

  private static Order GenerateNewOrder(Guid id)
  {
    return new Order
    {
      Id = id,
      Date = default,
      Number = default,
      KindOrderId = default,
      RequestId = default
    };
  }
}

