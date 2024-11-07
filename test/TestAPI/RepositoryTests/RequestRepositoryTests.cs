using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class RequestRepositoryTests
{
  private StudentContext _studentContext;
  private RequestRepository _requestRepository;
  private StudentRepository _studentRepository;
  private GroupStudentRepository _groupStudentRepository;
  private OrderRepository _orderRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentContext.Students.RemoveRange(this._studentContext.Students.ToList());
    this._studentContext.Requests.RemoveRange(this._studentContext.Requests.ToList());
    this._studentContext.Orders.RemoveRange(this._studentContext.Orders.ToList());
    this._groupStudentRepository = new GroupStudentRepository(this._studentContext);
    this._studentRepository = new StudentRepository(this._studentContext, this._groupStudentRepository);
    this._orderRepository = new OrderRepository(this._studentContext);
    this._requestRepository = new RequestRepository(this._studentContext, this._studentRepository, this._orderRepository);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task Create_AddSuccessfully()
  {
    // Arrange
    var request = GenerateRequest();

    // Act
    await this._requestRepository.Create(request);

    // Assert
    Assert.That(this._studentContext.Requests.FirstOrDefault(x => x.Id == request.Id),
      Is.Not.Null);
  }

  [Test]
  public async Task Create_AddSameRequest_ThrowException()
  {
    // Arrange
    var request = GenerateRequest();

    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = async () => await this._requestRepository.Create(request);

    //Assert
    Assert.That(result, Throws.InstanceOf<ArgumentException>());
  }

  [Test]
  public async Task Create_AddRequestWithExistingStudent_AddSuccessfully()
  {
    // Arrange
    var student = GenerateStudent();

    var request = GenerateRequest();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    // Act
    await this._requestRepository.Create(request);

    //Assert
    Assert.That(this._studentContext.Requests.FirstOrDefault(x => x.Id == request.Id),
      Is.Not.Null);
  }

  [Test]
  public async Task FindRequestByEmailFromRequestAsync_FindSuccessfully()
  {
    // Arrange
    var request = GenerateRequest();

    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = await this._requestRepository.FindRequestByEmailFromRequestAsync(request);

    // Assert
    Assert.That(result.Id, Is.EqualTo(request.Id));
  }

  [Test]
  public void FindRequestByEmailFromRequestAsync_RequestIsNull_ThrowException()
  {
    // Arrange
    Request request = null;

    // Act
    var result = async () => await this._requestRepository.FindRequestByEmailFromRequestAsync(request);

    // Assert
    Assert.That(result, Throws.InstanceOf<ArgumentException>());
  }

  [Test]
  public async Task FindRequestByEmailFromRequestAsync_RequestNotExists_ReturnNull()
  {
    // Arrange
    var request = GenerateRequest();

    // Act
    var result = await this._requestRepository.FindRequestByEmailFromRequestAsync(request);

    // Assert
    Assert.That(result, Is.Null);
  }

  [Test]
  public async Task FindRequestByPhoneFromRequestAsync_FindSuccessfully()
  {
    // Arrange
    var request = GenerateRequest();

    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = await this._requestRepository.FindRequestByPhoneFromRequestAsync(request);

    // Assert
    Assert.That(result.Id, Is.EqualTo(request.Id));
  }

  [Test]
  public void FindRequestByPhoneFromRequestAsync_RequestIsNull_ThrowException()
  {
    // Arrange
    Request request = null;

    // Act
    var result = async () => await this._requestRepository.FindRequestByPhoneFromRequestAsync(request);

    // Assert
    Assert.That(result, Throws.InstanceOf<ArgumentException>());
  }

  [Test]
  public async Task AddOrderToRequest_AddSuccessfully()
  {
    // Arrange
    var order = GenerateOrder();

    var request = GenerateRequest();

    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = await this._requestRepository.AddOrderToRequest(request.Id, order);

    // Assert
    Assert.That(this._orderRepository.FindById(order.Id).Result.RequestId, Is.EqualTo(request.Id));
  }

  [Test]
  public void AddOrderToRequest_RequestIdNotExists_ThrowException()
  {
    // Arrange
    var order = GenerateOrder();

    var requestId = Guid.NewGuid();

    // Act
    var result = async () => await this._requestRepository.AddOrderToRequest(requestId, order);

    // Assert
    Assert.That(result, Throws.InstanceOf<ArgumentException>());
  }

  [Test]
  public async Task GetRequestsByPage_GetSuccessfully()
  {
    // Arrange
    var requests = new List<Request>();
    for (var i = 0; i < 5; i++)
    {
      requests.Add(GenerateRequest());
    }

    this._studentContext.Requests.AddRange(requests);
    await this._studentContext.SaveChangesAsync();

    var page = 2;
    var pageSize = 2;

    // Act
    var result = await this._requestRepository.GetRequestsByPage(page, pageSize);

    // Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Data, Has.Count.EqualTo(2));
    });
  }

  [Test]
  public async Task GetRequestsByPage_DontHaveNextPage_GetSuccessfully()
  {
    // Arrange
    var requests = new List<Request>();
    for(var i = 0; i < 3; i++)
    {
      requests.Add(GenerateRequest());
    }

    this._studentContext.Requests.AddRange(requests);
    await this._studentContext.SaveChangesAsync();

    var page = 1;
    var pageSize = 3;

    // Act
    var result = await this._requestRepository.GetRequestsByPage(page, pageSize);

    // Assert
    Assert.That(result.HasNext, Is.False);
  }

  [Test]
  public async Task GetRequestsDTOByPage_GetSuccessfully()
  {
    // Arrange
    var requests = new List<Request>();
    for (var i = 0; i < 5; i++)
    {
      requests.Add(GenerateRequest());
    }

    this._studentContext.Requests.AddRange(requests);
    await this._studentContext.SaveChangesAsync();

    var page = 2;
    var pageSize = 2;

    // Act
    var result = await this._requestRepository.GetRequestsDTOByPage(page, pageSize);

    // Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Data, Has.Count.EqualTo(2));
    });
  }

  private static Request GenerateRequest()
  {
    return new Request
    {
      Id = Guid.NewGuid(),
      StudentId = Guid.NewGuid(),
      EducationProgramId = Guid.NewGuid(),
      DocumentRiseQualificationId = Guid.NewGuid(),
      DataNumberDogovor = default,
      StatusRequestId = Guid.NewGuid(),
      StudentStatusId = Guid.NewGuid(),
      StatusEntrancExams = default,
      Phone = "+7 (123) 456-78-90",
      Email = "test@gmail.com",
      Agreement = default
    };
  }

  private static Order GenerateOrder()
  {
    return new Order
    {
      Id = Guid.NewGuid(),
      Number = "null",
      Date = default,
      KindOrderId = Guid.NewGuid(),
      RequestId = default,
    };
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
}