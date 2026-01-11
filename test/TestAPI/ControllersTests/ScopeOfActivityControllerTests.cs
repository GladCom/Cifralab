using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class ScopeOfActivityControllerTests
{
  private StudentContext _studentContext;
  private ScopeOfActivityController _scopeOfActivityController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._scopeOfActivityController = new ScopeOfActivityController(
      TestsDepends.GetGenericRepository<ScopeOfActivity>(this._studentContext), new TestLogger<ScopeOfActivity>())
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
