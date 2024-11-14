using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Students.APIServer.Controllers;

namespace TestAPI.ControllersTests;

[TestFixture]
public class LivenessControllerTests
{
  private LivenessController _controller;

  [SetUp]
  public void SetUp()
  {
    this._controller = new LivenessController(new TestLogger<LivenessController>());

    this._controller.ControllerContext = new ControllerContext
    {
      HttpContext = new DefaultHttpContext()
    };
  }

  [TearDown]
  public void TearDown()
  {
  }

  [Test]
  public void Get_ReturnsOkResult_WithExpectedResponse()
  {
    // Act
    var result = this._controller.Get() as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result?.StatusCode, Is.EqualTo(200));
    });
  }
}