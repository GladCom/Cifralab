using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

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
      TestsDepends.GetGenericRepository<TypeEducation>(this._studentContext), new TestLogger<TypeEducation>())
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
