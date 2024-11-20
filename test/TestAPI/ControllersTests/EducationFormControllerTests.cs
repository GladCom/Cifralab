using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class EducationFormControllerTests
{
  private StudentContext _studentContext;
  private EducationFormController _educationFormController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._educationFormController = new EducationFormController(
      new GenericRepository<EducationForm>(this._studentContext), new TestLogger<EducationForm>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.EducationForms.RemoveRange(this._studentContext.Set<EducationForm>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
