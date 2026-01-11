using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using TestAPI.Utilities;
using Group = Students.Models.Group;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class GroupStudentRepositoryTests
{
  private StudentContext _studentContext;
  private IGroupStudentRepository _groupStudentRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._groupStudentRepository = TestsDepends.GetGroupStudentRepository(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task Create_NewGroupStudent_Success()
  {
    //Arrange
    var student = GenerateStudent();
    this._studentContext.Add(student);

    var request = GenerateRequest(student.Id);
    this._studentContext.Add(request);

    var group = GenerateGroup();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualGroupStudent = await this._groupStudentRepository.Create(request, group.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualGroupStudent, Is.Not.Null);
      Assert.That(actualGroupStudent!.StudentId, Is.EqualTo(student.Id));
      Assert.That(actualGroupStudent.GroupId, Is.EqualTo(group.Id));
      Assert.That(actualGroupStudent.RequestId, Is.EqualTo(request.Id));
    });
  }

  [Test]
  public async Task Create_Request_IsNull()
  {
    //Arrange
    Request? request = null;

    var group = GenerateGroup();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualGroupStudent = await this._groupStudentRepository.Create(request, group.Id);

    //Assert
    Assert.That(actualGroupStudent, Is.Null);
  }

  [Test]
  public async Task Create_StudentId_IsNullException()
  {
    //Arrange
    var request = GenerateRequest(null);
    this._studentContext.Add(request);

    var group = GenerateGroup();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualGroupStudent = await this._groupStudentRepository.Create(request, group.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualGroupStudent, Is.Null);
    });
  }

  [Test]
  public async Task Create_Student_NotExistException()
  {
    //Arrange
    var student = GenerateStudent();

    var request = GenerateRequest(student.Id);
    this._studentContext.Add(request);

    var group = GenerateGroup();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualGroupStudent = await this._groupStudentRepository.Create(request, group.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualGroupStudent, Is.Null);
    });
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

  private static Request GenerateRequest(Guid? studentId)
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
