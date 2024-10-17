using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Group = Students.Models.Group;

namespace TestAPI;

public class GroupRepositoryTests
{
  private StudentContext _studentContext;
  private GroupRepository _groupRepository;

  private readonly List<Guid> _guids = new()
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
    this._groupRepository = new GroupRepository(this._studentContext, new GroupStudentRepository(this._studentContext));
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task AddStudentsInGroup_NewStudents_AddSuccessfully()
  {
    //Arrange
    const int expected = 3;

    var students = GenerateNewStudents(this._guids.GetRange(0, expected));
    this._studentContext.AddRange(students);

    var group = GenerateNewGroup(this._guids[expected + 1]);
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    await this._groupRepository.AddStudentsInGroup(students, group.Id);

    //Assert
    var actual = 0;
    foreach(var student in students)
    {

      if(this._studentContext.GroupStudent.FirstOrDefault(sg => sg.GroupsId == group.Id && sg.StudentsId == student.Id)
          is not null)
        actual++;
    }

    Assert.That(actual, Is.EqualTo(expected));
  }

  [Test]
  public async Task AddStudentsInGroup_NewStudentsIsNull_Exception()
  {
    //Arrange
    List<Student>? students = null;
    var group = GenerateNewGroup(this._guids[0]);

    this._studentContext.Add(group);
    await this._studentContext.SaveChangesAsync();

    //Act
    var act = async () => await this._groupRepository.AddStudentsInGroup(students, group.Id);

    //Assert
    Assert.That(act, Throws.InstanceOf<NullReferenceException>());
  }

  [Test]
  public async Task AddStudentsInGroup_IdOfANonExistentGroup_Exception()
  {
    //Arrange
    var students = GenerateNewStudents(this._guids.GetRange(0, 3));
    this._studentContext.AddRange(students);

    await this._studentContext.SaveChangesAsync();

    //Act
    var act = async () => await this._groupRepository.AddStudentsInGroup(students, Guid.Empty);

    //Assert
    Assert.That(act, Throws.InstanceOf<InvalidOperationException>());
  }

  private static List<Student> GenerateNewStudents(List<Guid> id)
  {
    return id.Select(GenerateNewStudent).ToList();
  }

  private static Student GenerateNewStudent(Guid id)
  {
    return new Student
    {
      Id = id,
      Family = "null",
      BirthDate = default,
      Sex = default,
      Address = "null",
      Phone = "null",
      Email = "null",
      IT_Experience = "null",
      ScopeOfActivityLevelOneId = default
    };
  }

  private static Group GenerateNewGroup(Guid id)
  {
    return new Group
    {
      Id = id,
      EducationProgramId = default,
      StartDate = default,
      EndDate = default
    };
  }
}
