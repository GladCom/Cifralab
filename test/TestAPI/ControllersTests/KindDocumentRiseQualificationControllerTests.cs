using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class KindDocumentRiseQualificationControllerTests
{
  private StudentContext _studentContext;
  private KindDocumentRiseQualificationController _kindDocumentRiseQualificationController;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._kindDocumentRiseQualificationController = new KindDocumentRiseQualificationController(
      TestsDepends.GetGenericRepository<KindDocumentRiseQualification>(this._studentContext), new TestLogger<KindDocumentRiseQualification>())
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
