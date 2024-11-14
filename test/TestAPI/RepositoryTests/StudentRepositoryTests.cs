using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Group = Students.Models.Group;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class StudentRepositoryTests
{
  private StudentContext _studentContext;
  private StudentRepository _studentRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentContext.Students.RemoveRange(this._studentContext.Students.ToList());
    this._studentContext.Groups.RemoveRange(this._studentContext.Groups.ToList());
    this._studentContext.Requests.RemoveRange(this._studentContext.Requests.ToList());
    this._studentRepository = new StudentRepository(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task GetStudentsByPage_GetStudentsSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();
    var student2 = GenerateStudent();

    var page = 1;
    var pageSize = 3;

    this._studentContext.Students.Add(student);
    this._studentContext.Students.Add(student2);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = this._studentRepository.GetStudentsByPage(page, pageSize);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Result.Data.ToList(), Has.Count.EqualTo(2));
      Assert.That(result.Result.HasNext, Is.False);
    });
  }

  [Test]
  public async Task GetStudentWithGroupsAndRequests_FindSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();
    this._studentContext.Add(student);

    var request = GenerateRequest(student.Id);
    this._studentContext.Add(request);

    var group = GenerateGroup();
    this._studentContext.Add(group);

    var groupStudent = new GroupStudent
    {
      StudentId = student.Id,
      GroupId = group.Id,
      RequestId = request.Id
    };

    this._studentContext.Add(groupStudent);

    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._studentRepository.GetStudentWithGroupsAndRequests(student.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Id, Is.EqualTo(student.Id));
      Assert.That(1, Is.EqualTo(result.Groups!.Count));
      Assert.That(1, Is.EqualTo(result.Requests!.Count));
    });
  }

  [Test]
  public async Task GetStudentWithGroupsAndRequests_IdNotExists_ReturnNull()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    var newStudentGiud = Guid.NewGuid();

    //Act
    var result = await this._studentRepository.GetStudentWithGroupsAndRequests(newStudentGiud);

    //Assert
    Assert.That(result, Is.Null);
  }

  private static Student GenerateStudent()
  {
    return new Student
    {
      Id = Guid.NewGuid(),
      Family = "null",
      BirthDate = default,
      Sex = default,
      Address = "null",
      Phone = "+7 (123) 456-78-90",
      Email = "test@gmail.com",
      IT_Experience = "null",
      ScopeOfActivityLevelOneId = default
    };
  }

  private static Group GenerateGroup()
  {
    return new Group
    {
      Id = Guid.NewGuid(),
      EducationProgramId = default,
      StartDate = default,
      EndDate = default
    };
  }

  private static Request GenerateRequest(Guid studentId)
  {
    return new Request
    {
      Id = Guid.NewGuid(),
      StudentId = studentId,
      Phone = "+7 (123) 456-78-90",
      Email = "test@gmail.com",
      Agreement = default
    };
  }
}