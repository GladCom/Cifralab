using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class FEAProgramControllerTests
{
  private StudentContext _studentContext;
  private FEAProgramController _feaProgramController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._feaProgramController = new FEAProgramController(
      new FEAProgramRepository(this._studentContext), new TestLogger<FEAProgram>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.FEAPrograms.RemoveRange(this._studentContext.Set<FEAProgram>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
