using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class KindOrderControllerTests
{
  private StudentContext _studentContext;
  private KindOrderController _kindOrderController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._kindOrderController = new KindOrderController(
      TestsDepends.GetGenericRepository<KindOrder>(this._studentContext), new TestLogger<KindOrder>())
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
