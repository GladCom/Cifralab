using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class KindEducationProgramControllerTests
{
  private StudentContext _studentContext;
  private KindEducationProgramController _kindEducationProgramController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._kindEducationProgramController = new KindEducationProgramController(
      TestsDepends.GetGenericRepository<KindEducationProgram>(this._studentContext), new TestLogger<KindEducationProgram>())
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
