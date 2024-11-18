using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class FinancingTypeControllerTests
{
  private StudentContext _studentContext;
  private FinancingTypeController _financingTypeController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._financingTypeController = new FinancingTypeController(
      new FinancingTypeRepository(this._studentContext), new TestLogger<FinancingType>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.FinancingTypes.RemoveRange(this._studentContext.Set<FinancingType>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
