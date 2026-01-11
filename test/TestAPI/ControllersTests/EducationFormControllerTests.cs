using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class EducationFormControllerTests
{
  private StudentContext _studentContext;
  private EducationFormController _educationFormController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._educationFormController = new EducationFormController(
      TestsDepends.GetGenericRepository<EducationForm>(this._studentContext), new TestLogger<EducationForm>())
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
