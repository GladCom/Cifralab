using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using TestAPI.Utilities;
using Group = Students.Models.Group;

namespace TestAPI.ControllersTests;

[TestFixture]
public class GroupControllerTests
{
  private StudentContext _studentContext;
  private GroupController _groupController;

  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("aa634441-8637-417c-8c00-895753b37cbe"),
    Guid.Parse("c111b3f8-c212-4a40-851a-76817bf004cf"),
    Guid.Parse("8c8801af-5dde-421e-92ba-755b359e2452")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._groupController = new GroupController(
      TestsDepends.GetGroupRepository(this._studentContext), new TestLogger<Group>())
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

  [Test]
  public async Task AddStudentsToGroupByRequest_GroupNotExists_NotFound()
  {
    //Arrange
    var requests = new List<Guid>();

    //Act
    var result = await this._groupController.AddStudentsToGroupByRequest(requests, this._guids[0]);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_EmptyStudents_Ok()
  {
    //Arrange
    var requests = new List<Guid>();
    var group = GenerateNewGroup(this._guids[0], "Группа1", Guid.Empty);
    this._studentContext.Groups.Add(group);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._groupController.AddStudentsToGroupByRequest(requests, group.Id);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    });
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_Ok()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0], Guid.Empty);
    var group = GenerateNewGroup(this._guids[1], "Группа1", Guid.Empty);
    var request = GenerateNewRequest(this._guids[2], this._guids[0], Guid.Empty);
    this._studentContext.Students.Add(student);
    this._studentContext.Groups.Add(group);
    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();
    var requests = new List<Guid>() { request.Id };

    //Act
    var result = await this._groupController.AddStudentsToGroupByRequest(requests, group.Id);

    // Assert
    var okResult = result as ObjectResult;
    var countBadRequest = (okResult?.Value as IEnumerable<Guid>)?.Count();
    var resultGroupStudent = await this._studentContext.GroupStudent.FindAsync(request.Id);

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(countBadRequest, Is.EqualTo(0));
      Assert.That(resultGroupStudent, Is.Not.Null);
    });
  }

  [Test]
  public async Task RemoveStudentsFromGroupByRequest_Ok()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0], Guid.Empty);
    var group = GenerateNewGroup(this._guids[1], "Группа1", Guid.Empty);
    var request = GenerateNewRequest(this._guids[2], this._guids[0], Guid.Empty);
    this._studentContext.Students.Add(student);
    this._studentContext.Groups.Add(group);
    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();
    var requests = new List<Guid>() { request.Id };
    await this._groupController.AddStudentsToGroupByRequest(requests, group.Id);
    var students = new List<Guid>() { student.Id };

    //Act
    var result = await this._groupController.RemoveStudentsFromGroupByRequest(students, group.Id);

    // Assert
    var okResult = result as ObjectResult;
    var resultGroupStudent = await this._studentContext.GroupStudent.FindAsync(request.Id);

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(resultGroupStudent, Is.Null);
    });
  }

  [Test]
  public async Task RemoveStudentsFromGroupByRequest_GroupNotExists_NotFound()
  {
    //Arrange
    var students = new List<Guid>() { this._guids[0] };

    //Act
    var result = await this._groupController.RemoveStudentsFromGroupByRequest(students, this._guids[1]);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task RemoveStudentsFromGroupByRequest_EmptyStudentList_Ok()
  {
    //Arrange
    var group = GenerateNewGroup(this._guids[1], "Группа1", Guid.Empty);
    this._studentContext.Groups.Add(group);
    await this._studentContext.SaveChangesAsync();
    var students = new List<Guid>();

    //Act
    var result = await this._groupController.RemoveStudentsFromGroupByRequest(students, group.Id);

    // Assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    });
  }

  private static Student GenerateNewStudent(Guid id, Guid typeEducationId, string family = "Иванов", string name = "Иван", string patron = "Иванович",
    string email = "email@mail.ru", string phone = "+7 (123) 456-78-90")
  {
    return new Student()
    {
      Id = id,
      Surname = family,
      Name = name,
      Patron = patron,
      BirthDate = DateOnly.Parse("01.01.2000"),
      Sex = default,
      Nationality = default,
      SNILS = "000-000-000 00",
      Address = string.Empty,
      Phone = phone,
      Email = email,
      Projects = default,
      IT_Experience = string.Empty,
      Disability = default,
      TypeEducationId = typeEducationId,
      ScopeOfActivityLevelOneId = default,
      ScopeOfActivityLevelTwoId = default,
      Speciality = default,
      FullNameDocument = default,
      DocumentSeries = default,
      DocumentNumber = default,
      DateTakeDiplom = default
    };
  }

  private static Request GenerateNewRequest(Guid id, Guid studentId, Guid educationProgramId)
  {
    return new Request
    {
      Id = id,
      StudentId = studentId,
      EducationProgramId = educationProgramId,
      DocumentRiseQualificationId = default,
      DataNumberDogovor = default,
      StatusRequestId = default,
      StudentStatusId = default,
      StatusEntrancExams = StatusEntrancExams.Done,
      RegistrationNumber = default,
      Email = "email@mail.ru",
      Phone = "+7 (123) 111-22-33",
      Agreement = true
    };
  }

  private static Group GenerateNewGroup(Guid id, string name, Guid educationProgramId)
  {
    return new Group()
    {
      Id = id,
      Name = name,
      EducationProgramId = educationProgramId,
      StartDate = default,
      EndDate = default
    };
  }
}

