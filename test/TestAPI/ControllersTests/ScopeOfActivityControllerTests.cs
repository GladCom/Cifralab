using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class ScopeOfActivityControllerTests
{
  private StudentContext _studentContext;
  private ScopeOfActivityController _scopeOfActivityController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._scopeOfActivityController = new ScopeOfActivityController(
      new GenericRepository<ScopeOfActivity>(this._studentContext), new TestLogger<ScopeOfActivity>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.ScopesOfActivity.RemoveRange(this._studentContext.Set<ScopeOfActivity>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
