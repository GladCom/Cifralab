using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Group = Students.Models.Group;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class GroupStudentRepositoryTests
{
  private StudentContext _studentContext;
  private GroupStudentRepository _groupStudentRepository;

  private readonly List<Guid> _guidList = new()
  {
    new Guid("20185546-cd61-4468-85a2-7c96a97cdb20"),
    new Guid("e2c25dc3-df83-407f-95df-28fab1f1e270"),
    new Guid("f98695a8-eb69-4361-b371-175f8850573d"),
    new Guid("2f8843a7-9169-43aa-92cc-57abc290db5f"),
    new Guid("cf4ff827-5f94-4b47-990f-805a5612c86f"),
    new Guid("be3c8544-89a1-4921-99e0-d15d3dbef21c"),
    new Guid("4fa97c78-2a7f-4cc5-b2d0-5c9049f96817"),
    new Guid("714c1786-8322-4a92-968d-661b56df9996"),
    new Guid("d4520960-119b-40e5-9a87-47e3cf8a7432")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentContext.Students.RemoveRange(this._studentContext.Set<Student>());
    this._studentContext.Groups.RemoveRange(this._studentContext.Set<Group>());
    this._studentContext.GroupStudent.RemoveRange(this._studentContext.Set<GroupStudent>());
    this._groupStudentRepository = new GroupStudentRepository(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }
}
