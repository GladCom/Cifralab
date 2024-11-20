using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI.ControllersTests;

[TestFixture]
public class DocumentRiseQualificationControllerTests
{
  private StudentContext _studentContext;
  private DocumentRiseQualifacationController _documentRiseQualificationController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._documentRiseQualificationController = new DocumentRiseQualifacationController(
      new GenericRepository<DocumentRiseQualification>(this._studentContext), new TestLogger<DocumentRiseQualification>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.DocumentRiseQualifications.RemoveRange(this._studentContext.Set<DocumentRiseQualification>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
