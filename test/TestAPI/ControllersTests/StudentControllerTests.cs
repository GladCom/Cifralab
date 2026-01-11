using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Students.APIServer.Controllers;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.Enums;
using Students.Models.WebModels;
using TestAPI.Utilities;

namespace TestAPI.ControllersTests;

[TestFixture]
public class StudentControllerTests
{
  private Mock<IStudentRepository> _studentRepositoryMock;
  private StudentController _controller;

  [SetUp]
  public void SetUp()
  {
    this._studentRepositoryMock = new Mock<IStudentRepository>();
    this._controller = new StudentController(this._studentRepositoryMock.Object, new TestLogger<Student>());

    var httpContext = new DefaultHttpContext();
    this._controller.ControllerContext = new ControllerContext
    {
      HttpContext = httpContext
    };
  }

  [TearDown]
  public void TearDown()
  {
    this._studentRepositoryMock.Reset();
  }

  [Test]
  public async Task ListAllPaged_ReturnsOkResult_WithStudentsSuccessfully()
  {
    // Arrange
    var page = GeneratePageable();
    var students = GenerateListStudents();
    var pagedPage = new PagedPage<StudentDTO>(students, students.Count, page.PageNumber, page.PageSize);

    // настройка фиктивных  данных (mock-обьектов)
    this._studentRepositoryMock.Setup(repo => repo.GetStudentsByPage(page.PageNumber, page.PageSize))
            .ReturnsAsync(pagedPage);

    // Act
    var result = await this._controller.ListAllPaged(page);

    //Assert
    Assert.IsInstanceOf<ObjectResult>(result);

    Assert.Multiple(() =>
    {
      var okResult = result as ObjectResult;

      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));

      var returnedPage = okResult.Value as PagedPage<StudentDTO>;
      Assert.That(returnedPage, Is.Not.Null);
      Assert.That(returnedPage.PageSize, Is.EqualTo(pagedPage.PageSize));
      Assert.That(returnedPage.CurrentPage, Is.EqualTo(pagedPage.CurrentPage));
      Assert.That(returnedPage.TotalPages, Is.EqualTo(pagedPage.TotalPages));
      Assert.That(returnedPage.TotalCount, Is.EqualTo(pagedPage.TotalCount));
      Assert.That(returnedPage.Data, Is.EqualTo(pagedPage.Data));
    });
  }

  [Test]
  public async Task ListAllPaged_NotExistsPages_ReturnNullPages()
  {
    // Arrange
    var page = GeneratePageable();
    var students = GenerateListStudents();
    var pagedPage = new PagedPage<StudentDTO>(students, students.Count, page.PageNumber, page.PageSize);

    // настройка фиктивных  данных (mock-обьектов)
    this._studentRepositoryMock.Setup(repo => repo.GetStudentsByPage(page.PageNumber, page.PageSize))!
      .ReturnsAsync((PagedPage<StudentDTO>?)null);

    // Act
    var result = await this._controller.ListAllPaged(page);

    //Assert
    Assert.IsInstanceOf<ObjectResult>(result);

    Assert.Multiple(() =>
    {
      var okResult = result as ObjectResult;

      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult!.StatusCode, Is.EqualTo(StatusCodes.Status200OK));

      var returnedPage = okResult.Value as PagedPage<Student>;
      Assert.That(returnedPage, Is.Null);
    });
  }

  [Test]
  public async Task GetStudentWithGroupsAndRequests_Successfully()
  {
    // Arrange
    var student = GenerateStudent();
    // Настройка фиктивных данных (mock-объектов) при получении студента
    this._studentRepositoryMock.Setup(repo => repo.GetStudentWithGroupsAndRequests(student.Id)).ReturnsAsync(student);

    // Act
    var result = await this._controller.GetStudentWithGroupsAndRequests(student.Id);

    // Assert
    Assert.IsInstanceOf<ObjectResult>(result);

    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult!.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      var returnedStudent = okResult.Value as Student;
      Assert.That(returnedStudent, Is.Not.Null);
      Assert.That(returnedStudent!.Id, Is.EqualTo(student.Id));
    });
  }

  [Test]
  public async Task Get_ReturnsNotFound_WhenStudentIsNull()
  {
    // Arrange
    var studentId = Guid.NewGuid();
    // Настройка фиктивных данных (mock-объектов) при получении студента, который отсутствует
    this._studentRepositoryMock.Setup(repo => repo.GetStudentWithGroupsAndRequests(studentId)).ReturnsAsync((Student?)null);

    // Act
    var result = await this._controller.GetStudentWithGroupsAndRequests(studentId);

    // Assert
    Assert.IsInstanceOf<ObjectResult>(result);

    var notFoundResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(notFoundResult, Is.Not.Null);
      Assert.That(notFoundResult!.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));

      var response = notFoundResult.Value as DefaultResponse;
      Assert.That(response, Is.Not.Null);
      Assert.That(response!.RequestId,
        Is.EqualTo(Activity.Current?.Id ?? this._controller.HttpContext.TraceIdentifier));
    });
  }

  private static Student GenerateStudent()
  {
    return new Student
    {
      Id = Guid.NewGuid(),
      Family = "Иванов",
      Name = "Иван",
      Patron = "Иванович",
      BirthDate = new DateOnly(2000, 5, 20),
      Sex = SexHuman.Men,  // допустим, что SexHuman - это перечисление с полами
      Address = "ул. Ленина, д. 10, кв. 5",
      Phone = "+7 (951) 675-87-57",  // соответствует шаблону телефона
      Email = "validemail@example.com",  // соответствует шаблону Email
      IT_Experience = "3 года",
      ScopeOfActivityLevelOneId = Guid.NewGuid(),  // случайный Guid
      SNILS = "123-456-789 00",  // соответствует шаблону СНИЛС
      TypeEducationId = Guid.NewGuid()  // случайный Guid, указывающий на уровень образования
    };
  }

  private static List<StudentDTO> GenerateListStudents()
  {
    var students = new List<StudentDTO>
    {
      Mapper.StudentToStudentDTO(GenerateStudent()).Result,
      Mapper.StudentToStudentDTO(GenerateStudent()).Result
    };

    return students;
  }

  private static Pageable GeneratePageable()
  {
    return new Pageable
    {
      PageNumber = 3,
      PageSize = 5
    };
  }
}