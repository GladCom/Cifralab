using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class StatusRequestControllerTests
{
  private StudentContext _studentContext;
  private StatusRequestController _statusRequestController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._statusRequestController = new StatusRequestController(
    TestsDepends.GetGenericRepository<StatusRequest>(this._studentContext), new TestLogger<StatusRequest>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
