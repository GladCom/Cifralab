using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class KindEducationProgramControllerTests
{
  private StudentContext _studentContext;
  private KindEducationProgramController _kindEducationProgramController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._kindEducationProgramController = new KindEducationProgramController(
      new GenericRepository<KindEducationProgram>(this._studentContext), new TestLogger<KindEducationProgram>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.KindEducationPrograms.RemoveRange(this._studentContext.Set<KindEducationProgram>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
