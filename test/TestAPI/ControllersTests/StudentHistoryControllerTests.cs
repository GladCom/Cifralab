using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class StudentHistoryControllerTests
{
  private StudentContext _studentContext;
  private StudentHistoryController _studentHistoryController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._studentHistoryController = new StudentHistoryController(
      TestsDepends.GetStudentHistoryRepository(this._studentContext), new TestLogger<StudentHistory>())
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
