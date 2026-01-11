using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class DocumentRiseQualificationControllerTests
{
  private StudentContext _studentContext;
  private DocumentRiseQualifacationController _documentRiseQualificationController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._documentRiseQualificationController = new DocumentRiseQualifacationController(
      TestsDepends.GetGenericRepository<DocumentRiseQualification>(this._studentContext), new TestLogger<DocumentRiseQualification>())
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
