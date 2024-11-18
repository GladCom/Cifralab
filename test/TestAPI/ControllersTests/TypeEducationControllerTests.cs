using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class TypeEducationControllerTests
{
  private StudentContext _studentContext;
  private TypeEducationController _typeEducationController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._typeEducationController = new TypeEducationController(
      new GenericRepository<TypeEducation>(this._studentContext), new TestLogger<TypeEducation>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.TypeEducation.RemoveRange(this._studentContext.Set<TypeEducation>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
