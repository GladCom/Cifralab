using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class StatusRequestControllerTests
{
  private StudentContext _studentContext;
  private StatusRequestController _statusRequestController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._statusRequestController = new StatusRequestController(
      new GenericRepository<StatusRequest>(this._studentContext), new TestLogger<StatusRequest>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.StatusRequests.RemoveRange(this._studentContext.Set<StatusRequest>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
