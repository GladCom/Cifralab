using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class LivenessControllerTests
{
  private LivenessController _controller;

  [SetUp]
  public void SetUp()
  {
    this._controller = new LivenessController(new TestLogger<LivenessController>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
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