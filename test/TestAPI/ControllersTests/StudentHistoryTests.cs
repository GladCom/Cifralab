using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class StudentHistoryTests
{
  private StudentContext _studentContext;
  private StudentHistoryController _studentHistoryController;
  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentHistoryController = new StudentHistoryController(
      new StudentHistoryRepository(this._studentContext, new StudentRepository(this._studentContext)), new TestLogger<StudentHistory>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.StudentHistories.RemoveRange(this._studentContext.Set<StudentHistory>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
