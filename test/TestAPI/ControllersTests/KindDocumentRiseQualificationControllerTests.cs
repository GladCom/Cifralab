using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class KindDocumentRiseQualificationControllerTests
{
  private StudentContext _studentContext;
  private KindDocumentRiseQualificationController _kindDocumentRiseQualificationController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._kindDocumentRiseQualificationController = new KindDocumentRiseQualificationController(
      new GenericRepository<KindDocumentRiseQualification>(this._studentContext), new TestLogger<KindDocumentRiseQualification>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.KindDocumentRiseQualifications.RemoveRange(this._studentContext.Set<KindDocumentRiseQualification>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
