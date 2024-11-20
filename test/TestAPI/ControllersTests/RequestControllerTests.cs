using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Controllers;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace TestAPI.ControllersTests;

[TestFixture]
public class RequestControllerTests
{
  private StudentContext _studentContext;
  private RequestController _requestController;

  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("aa634441-8637-417c-8c00-895753b37cbe"),
    Guid.Parse("c111b3f8-c212-4a40-851a-76817bf004cf"),
    Guid.Parse("8c8801af-5dde-421e-92ba-755b359e2452")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    var genericStatusRequestRepository = new GenericRepository<StatusRequest>(this._studentContext);
    var studentRepository = new StudentRepository(this._studentContext, new StudentHistoryRepository(this._studentContext));
    var orderRepository = new OrderRepository(this._studentContext);
    var fantomStudentRepository = new GenericRepository<PhantomStudent>(this._studentContext);
    var requestRepository = new RequestRepository(this._studentContext, orderRepository, studentRepository, genericStatusRequestRepository, fantomStudentRepository);
    this._requestController = new RequestController(requestRepository, new TestLogger<Request>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.Requests.RemoveRange(this._studentContext.Set<Request>());
    this._studentContext.Students.RemoveRange(this._studentContext.Set<Student>());
    this._studentContext.PhantomStudents.RemoveRange(this._studentContext.Set<PhantomStudent>());
    this._studentContext.Orders.RemoveRange(this._studentContext.Set<Order>());
    this._studentContext.SaveChangesAsync();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task GetRequestDTO_Ok()
  {
    //Arrange
    var request = GenerateNewRequest(this._guids[0]);
    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._requestController.GetRequestDTO(this._guids[0]);

    // Assert
    var okResult = result as ObjectResult;
    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okResult?.Value, Is.TypeOf<RequestDTO>());
      Assert.That((okResult?.Value as RequestDTO)?.Id, Is.EqualTo(this._guids[0]));
    });
  }

  [Test]
  public async Task GetRequestDTO_NotFound()
  {
    //Act
    var result = await this._requestController.GetRequestDTO(this._guids[0]);

    // Assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Post_RequestForNotExistStudent_Ok()
  {
    //Arrange
    const string name = "Андриан";
    const string patron = "Иванович";
    const string family = "Иванов";
    const string email = "email@mail.ru";
    const string birthDate = "01.01.2000";
    var date = DateOnly.Parse(birthDate);
    const string phone = "+7 (123) 456-78-99";

    var newRequest = GenerateNewRequestDto(name, patron, family, email, birthDate, phone);

    //Act
    var result = await this._requestController.Post(newRequest);

    // Assert
    var okResult = result as ObjectResult;

    var foundStudentAfterPost = this._studentContext.Students
      .Any(e => e.Phone == phone && e.BirthDate == date
                                 && e.Name == name && e.Patron == patron && e.Family == family);

    var foundPhantomStudentAfterPost = this._studentContext.PhantomStudents
      .Any(e => e.Phone == phone && e.BirthDate == date
                                    && e.Name == name && e.Patron == patron && e.Family == family);

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okResult?.Value, Is.TypeOf<Request>());
      Assert.That(foundStudentAfterPost, Is.False);
      Assert.That(foundPhantomStudentAfterPost, Is.True);
    });
  }

  [Test]
  public async Task Post_RequestForExistStudent_Ok()
  {
    //Arrange
    //данные студента в БД
    const string nameStudent = "Лика";
    const string patronStudent = "Ивановна";
    const string familyStudent = "Петрова";
    const string emailStudent = "email@mail.ru";
    const string birthDateStudent = "01.01.2000";
    const string phoneStudent = "+7 (123) 456-78-90";

    var student = GenerateNewStudent(this._guids[0], nameStudent, patronStudent, familyStudent, emailStudent,
      birthDateStudent, phoneStudent);
    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    var newRequest = GenerateNewRequestDto(nameStudent, patronStudent, familyStudent, emailStudent, birthDateStudent,
      phoneStudent);

    //Act
    var result = await this._requestController.Post(newRequest);

    // Assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okResult?.Value, Is.TypeOf<Request>());
      Assert.That((okResult?.Value as Request)?.StudentId, Is.EqualTo(this._guids[0]));
    });
  }

  [TestCase("")]
  [TestCase("ssss")]
  [TestCase("ssss@dddd")]
  [TestCase("ssss @dddd")]
  [TestCase("ssss@ dddd")]
  [TestCase("ssss@dddd.")]
  [TestCase("ssss@dddd. ru")]
  [TestCase("ssss@dddd .ru")]
  public async Task Post_NotValidEmail_InternalServerError(string email)
  {
    //Arrange
    var newRequest = GenerateNewRequestDto();
    newRequest.email = email;

    //Act
    var result = await this._requestController.Post(newRequest);

    // Assert
    var errorResult = result as ObjectResult;
    Assert.Multiple(() =>
    {
      Assert.That(errorResult, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
    });
  }

  [TestCase("")]
  [TestCase("ssss")]
  [TestCase("123456789")]
  [TestCase("+71234567890")]
  public async Task Post_NotValidPhone_InternalServerError(string phone)
  {
    //Arrange
    var newRequest = GenerateNewRequestDto();
    newRequest.phone = phone;

    //Act
    var result = await this._requestController.Post(newRequest);

    //Assert
    var errorResult = result as ObjectResult;
    Assert.Multiple(() =>
    {
      Assert.That(errorResult, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
    });
  }

  /// <summary>
  /// Проверить метод "Обновить заявку". 
  /// При условиях:
  /// Заявка уже существует. Студент по ней уже создан.
  /// В новых данных по заявке Id студента = null (то есть не задан).
  /// Если по ФИО, телефону и почте из новых данных заявки не найден студент,
  /// то создается новая запись по студенту, и привязывается к заявке.
  /// </summary>
  /// <returns>Тест пройден, если вернулся успешный результат 
  /// об обновлении данных заявки со значением типа RequestsDTO,
  /// создан новый студент и закреплен к заявке.</returns>
  [Test]
  public async Task Put_RequestWithNullStudentId_NotFoundStudentByStudentInfo_Ok()
  {
    //Arrange
    //создаем заявку + студента
    var newRequest = GenerateNewRequestDto();
    var resultPost = await this._requestController.Post(newRequest);
    var request = ((ObjectResult)resultPost).Value as Request;
    var requestId = request?.Id;
    var oldStudentId = request?.StudentId;

    //обновленные данные по заявке
    var requestDto = GenerateRequestsDto("Иван", "иванович", "Иванов", "mail@mail.ru", "+7 (111) 222-22-22");
        requestDto.ScopeOfActivityLevelOneId = new Guid("a5e1e718-4747-47f4-b7c3-08e56bb7ea34");

    //Act
    var result = await this._requestController.Put(requestId.Value, requestDto);

    // Assert
    var okResult = result as ObjectResult;

    var resultGet = await this._requestController.GetRequestDTO(requestId.Value);
    var getValue = ((ObjectResult)resultGet).Value as RequestDTO;
    var newStudentId = getValue?.StudentId;
    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okResult?.Value, Is.TypeOf<RequestDTO>());
      Assert.That(newStudentId, Is.Not.EqualTo(oldStudentId));
    });
  }

  /// <summary>
  /// Проверить метод "Обновить заявку". 
  /// При условиях:
  /// Заявка уже существует. Студент по ней уже создан.
  /// В новых данных по заявке Id студента = null
  /// </summary>
  /// <returns>Тест пройден, если вернулся успешный результат 200.</returns>
  [Test]
  public async Task Put_RequestWithNullStudentId_FoundStudentByStudentInfo_Ok()
  {
    //Arrange
    const string name = "Иван";
    const string patron = "иванович";
    const string family = "Иванов";
    const string phone = "+7 (111) 222-22-22";
    const string email = "mail@mail.ru";

    //создаем студента
    var student = GenerateNewStudent(this._guids[0], name, patron, family, email, "01.02.2020", phone);
    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    //создаем первоначальную заявку + студента
    var newRequest = GenerateNewRequestDto();
    var resultPost = await this._requestController.Post(newRequest);
    var request = ((ObjectResult)resultPost)?.Value as Request;
    var requestId = request?.Id;

    //обновленные данные по заявке 
    var requestDto = GenerateRequestsDto(name, patron, family, email, phone);

    //Act
    var result = await this._requestController.Put(requestId.Value, requestDto);

    // Assert
    var okResult = result as ObjectResult;

    var resultGet = await this._requestController.Get(requestId.Value);
    var getValue = ((ObjectResult)resultGet)?.Value as RequestDTO;
    var newStudentId = getValue?.StudentId;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okResult?.Value, Is.TypeOf<RequestDTO>());
      Assert.That(newStudentId, Is.Null);
    });
  }

  /// <summary>
  /// Проверить метод "Обновить заявку". 
  /// При условиях:
  /// Заявка уже существует. Студент по ней уже создан.
  /// В новых данных по заявке задан Id студента.
  /// По Id студента из новых данных заявки не найден студент 
  /// => хоть студент по id и не найден, все равно данные обновляются.
  /// </summary>
  /// <returns>Тест пройден, если вернулся результат 200.</returns>
  [Test]
  public async Task Put_RequestWithNotNullStudentId_NotFoundStudentById_Ok()
  {
    //Arrange
    const string name = "Иван";
    const string patron = "иванович";
    const string family = "Иванов";
    const string phone = "+7 (111) 222-22-22";
    const string email = "mail@mail.ru";

    var newRequest =
      GenerateNewRequestDto("Имя", "Отчество", "Фамилия", "aaaa@mail.ru", "01.02.2020", "+7 (912) 222-33-33");
    var resultPost = await this._requestController.Post(newRequest);
    var request = ((ObjectResult)resultPost).Value as Request;
    var requestId = request?.Id;

    var requestDto = GenerateRequestsDto(name, patron, family, email, phone, this._guids[0]);

    //Act
    var result = await this._requestController.Put(requestId.Value, requestDto);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    });
  }

  /// <summary>
  /// Проверить метод "Обновить заявку". 
  /// При условиях:
  /// Заявка уже существует. Студент по ней уже создан.
  /// В новых данных по заявке задан Id студента.
  /// По Id студента из новых данных заявки найден студент.
  /// По информации ФИО, номер телефона, почта студента из новых данных заявки 
  /// найден уже существующий студент с другим Id 
  /// => Id студента в заявке заменяется на Id найденного студента.
  /// </summary>
  /// <returns>Тест пройден, если вернулся результат 200.</returns>
  [Test]
  public async Task Put_RequestWithNotNullStudentId_FoundEqualStudentWithOtherId_Ok()
  {
    //Arrange
    const string name = "Иван";
    const string patron = "иванович";
    const string family = "Иванов";
    const string phone = "+7 (111) 222-22-22";
    const string email = "mail@mail.ru";

    //создаем студента
    var student = GenerateNewStudent(this._guids[0], name, patron, family, email, "01.02.2000", phone);
    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    //создаем первоначальную заявку
    var newRequest =
      GenerateNewRequestDto("Имя", "Отчество", "Фамилия", "aaaa@mail.ru", "01.02.2020", "+7 (912) 222-33-33");
    var resultPost = await this._requestController.Post(newRequest);
    var request = ((ObjectResult)resultPost).Value as Request;
    var requestId = request?.Id;
    var studentId = request?.StudentId;

    var requestDto = GenerateRequestsDto(name, patron, family, email, phone, studentId);

    //Act
    var result = await this._requestController.Put(requestId.Value, requestDto);

    // Assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    });
  }

  /// <summary>
  /// Проверить метод "Обновить заявку". 
  /// При условиях:
  /// Заявка уже существует. Студент по ней уже создан.
  /// В новых данных по заявке задан Id студента.
  /// По Id студента из новых данных заявки найден студент.
  /// По информации ФИО, номер телефона, почта студента из новых данных заявки 
  /// не найден студент с другим Id 
  /// => обновляются данные заявки и студента.
  /// </summary>
  /// <returns>Тест пройден, если результат 200.</returns>
  [Test]
  public async Task Put_RequestWithNotNullStudentId_FoundStudentById_Ok()
  {
    //Arrange
    const string name = "Иван";
    const string patron = "иванович";
    const string family = "Иванов";
    const string phone = "+7 (111) 222-22-22";
    const string email = "mail@mail.ru";

    //создаем студента
    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();
    var oldStudentEmail = student.Email;

    //создаем первоначальную заявку
    var newRequest = GenerateNewRequestDto("aaa", "aaaa", "aaaaa", "aaaaa@mail.ru", "01.02.2001", "+7 (912) 222-33-33");
    var resultPost = await this._requestController.Post(newRequest);
    var request = ((ObjectResult)resultPost).Value as Request;
    var requestId = request?.Id;

    //обновленные данные заявки
    var requestDto = GenerateRequestsDto(name, patron, family, email, phone, this._guids[0]);

    //Act
    var result = await this._requestController.Put(requestId.Value, requestDto);

    // Assert
    var okResult = result as ObjectResult;

    var foundStudentAfterPut = await this._studentContext.Students.FindAsync(this._guids[0]);

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okResult?.Value, Is.TypeOf<RequestDTO>());
      Assert.That(foundStudentAfterPut, Is.Not.Null);
      Assert.That(foundStudentAfterPut?.Email, Is.Not.EqualTo(oldStudentEmail));
      Assert.That(foundStudentAfterPut?.Email, Is.EqualTo(email));
    });
  }

  [Test]
  public async Task Put_RequestNotFound_NotFound()
  {
    //Arrange
    var newRequest = GenerateRequestsDto();

    //Act
    var result = await this._requestController.Put(this._guids[0], newRequest);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task AddOrderToRequest_Ok()
  {
    //Arrange
    var newRequest =
      GenerateNewRequestDto("Имя", "Отчество", "Фамилия", "aaaa@mail.ru", "01.02.2020", "+7 (912) 222-33-33");
    var resultPost = await this._requestController.Post(newRequest);
    var request = ((ObjectResult)resultPost).Value as Request;
    var requestId = request?.Id;

    var order = GenerateNewOrder(this._guids[0], requestId.Value);

    //Act
    var result = await this._requestController.AddOrderToRequest(requestId.Value, order);

    // Assert
    var okResult = result as StatusCodeResult;

    var foundRequestAfterPost = this._studentContext.Requests.Include(r => r.Orders).FirstOrDefault(e => e.Id == requestId.Value);
    var orderFromRequest = foundRequestAfterPost?.Orders?.FirstOrDefault(e => e.Id == this._guids[0]);

    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(foundRequestAfterPost, Is.Not.Null);
      Assert.That(foundRequestAfterPost?.Orders, Is.Not.Null);
      Assert.That(orderFromRequest, Is.Not.Null);
    });
  }

  [Test]
  public async Task AddOrderToRequest_RequestNotFound_NotFound()
  {
    //Arrange
    var order = GenerateNewOrder(this._guids[0], this._guids[1]);

    // Act
    var result = await this._requestController.AddOrderToRequest(this._guids[1], order);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task ListAllPagedDTO_NullListRequest_Ok()
  {
    //Arrange
    var pageable = new Pageable();

    // Act
    var result = await this._requestController.ListAllPagedDTO(pageable);

    // Assert
    var okResult = result as ObjectResult;
    var listRequest = okResult?.Value as PagedPage<RequestDTO>;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(listRequest, Is.Not.Null);
      Assert.That(listRequest?.TotalCount, Is.EqualTo(0));
    });
  }

  [Test]
  public async Task ListAllPagedDTO_Ok()
  {
    //Arrange
    var pageable = new Pageable();
    var newRequest = GenerateNewRequestDto();
    await this._requestController.Post(newRequest);
    var newRequest2 = GenerateNewRequestDto("Имя2", "Отчество2", "Фамилия2", "email2@mail.ru", "02.02.1999",
      "+7 (123) 456-22-22");
    await this._requestController.Post(newRequest2);

    // Act
    var result = await this._requestController.ListAllPagedDTO(pageable);

    // Assert
    var okResult = result as ObjectResult;
    var listRequest = okResult?.Value as PagedPage<RequestDTO>;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(listRequest, Is.Not.Null);
      Assert.That(listRequest?.TotalCount, Is.EqualTo(2));
    });
  }

  private static Order GenerateNewOrder(Guid id, Guid requestId)
  {
    return new Order
    {
      Id = id,
      Date = default,
      KindOrderId = default,
      RequestId = requestId
    };
  }

  private static Request GenerateNewRequest(Guid id, Guid? studentId = null)
  {
    return new Request
    {
      Id = id,
      StudentId = studentId,
      EducationProgramId = default,
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

  private static NewRequestDTO GenerateNewRequestDto(string name = "Имя", string patron = "Отчество",
    string family = "Фамилия", string email = "email@mail.ru", string birthDate = "01.01.1999",
    string phone = "+7 (123) 456-78-90")
  {
    return new NewRequestDTO
    {
      address = "",
      agreement = default,
      birthDate = DateOnly.Parse(birthDate),
      educationProgramId = default,
      email = email,
      family = family,
      iT_Experience = "",
      name = name,
      patron = patron,
      phone = phone,
      projects = "",
      scopeOfActivityLevelOneId = default,
      scopeOfActivityLevelTwoId = default,
      speciality = "",
      statusRequestId = default,
      typeEducationId = default,
      statusEntrancExams = 0
    };
  }

  private static RequestDTO GenerateRequestsDto(string name = "Иван", string patron = "иванович",
    string family = "Иванов", string email = "mail@mail.ru", string phone = "+7 (111) 222-22-22",
    Guid? studentId = null)
  {
    return new RequestDTO()
    {
      family = family,
      name = name,
      patron = patron,
      StudentFullName = "",
      BirthDate = DateOnly.Parse("01.01.2000"),
      Address = "Ижевск",
      TypeEducation = default,
      TypeEducationId = default,
      Email = email,
      Id = default,
      StudentId = studentId,
      EducationProgramId = default,
      EducationProgram = default,
      StatusRequest = default,
      StatusRequestId = default,
      IT_Experience = "",
      speciality = default,
      projects = default,
      statusEntrancExams = default,
      phone = phone,
      ScopeOfActivityLevelOneId = default,
      ScopeOfActivityLevelTwoId = default,
      agreement = default,
      Age = default
    };
  }

  private static Student GenerateNewStudent(Guid id, string name = "Имя", string patron = "Отчество",
    string family = "Фамилия", string email = "aaa@mail.ru", string birthDate = "01.01.1999",
    string phone = "+7 (111) 222-22-22")
  {
    DateOnly date = default;
    if(DateTime.TryParse(birthDate, out var datetime))
    {
      date = DateOnly.FromDateTime(datetime);
    }

    return new Student
    {
      Id = id,
      Name = name,
      Patron = patron,
      Family = family,
      BirthDate = date,
      Sex = default,
      Address = "null",
      Phone = phone,
      Email = email,
      IT_Experience = "null",
      ScopeOfActivityLevelOneId = default
    };
  }
}
