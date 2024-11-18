using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class StudentStatusControllerTests
{
  private StudentContext _studentContext;
  private StudentStatusController _studentStatusController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentStatusController = new StudentStatusController(
      new GenericRepository<StudentStatus>(this._studentContext), new TestLogger<StudentStatus>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.StudentStatuses.RemoveRange(this._studentContext.Set<StudentStatus>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}