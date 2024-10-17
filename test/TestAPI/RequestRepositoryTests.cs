using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI
{
  [TestFixture]
  public class RequestRepositoryTests
  {
    private StudentContext studentContext;
    private RequestRepository requestRepository;
    private StudentRepository studentRepository;
    private GroupStudentRepository groupStudentRepository;
    private OrderRepository orderRepository;

    [SetUp]
    public void SetUp()
    {
      studentContext = new InMemoryContext();
      studentContext.Students.RemoveRange(studentContext.Students.ToList());
      studentContext.Requests.RemoveRange(studentContext.Requests.ToList());
      studentContext.Orders.RemoveRange(studentContext.Orders.ToList());
      groupStudentRepository = new GroupStudentRepository(studentContext);
      studentRepository = new StudentRepository(studentContext, groupStudentRepository);
      orderRepository = new OrderRepository(studentContext);
      requestRepository = new RequestRepository(studentContext, studentRepository, orderRepository);
    }

    [TearDown]
    public void TearDown()
    {
      studentContext.Dispose();
    }

    [Test]
    public async Task Create_AddSuccessfully()
    {
      // Arrange
      Request request = GenerateRequest();

      // Act
      await requestRepository.Create(request);

      // Assert
      Assert.That(studentContext.Requests.FirstOrDefault(x => x.Id == request.Id),
        Is.Not.Null);
    }

    [Test]
    public async Task Create_AddSameRequest_ThrowException()
    {
      // Arrange
      Request request = GenerateRequest();

      studentContext.Requests.Add(request);
      await studentContext.SaveChangesAsync();

      // Act
      var result = async () => await requestRepository.Create(request);

      //Assert
      Assert.That(result, Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public async Task Create_AddRequestWithExistingStudent_AddSuccessfully()
    {
      // Arrange
      Student student = GenerateStudent();

      Request request = GenerateRequest();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      // Act
      await requestRepository.Create(request);

      //Assert
      Assert.That(studentContext.Requests.FirstOrDefault(x => x.Id == request.Id),
        Is.Not.Null);
    }

    [Test]
    public async Task FindRequestByEmailFromRequestAsync_FindSuccessfully()
    {
      // Arrange
      Request request = GenerateRequest();

      studentContext.Requests.Add(request);
      await studentContext.SaveChangesAsync();

      // Act
      var result = await requestRepository.FindRequestByEmailFromRequestAsync(request);

      // Assert
      Assert.That(result.Id, Is.EqualTo(request.Id));
    }

    [Test]
    public async Task FindRequestByEmailFromRequestAsync_RequestIsNull_ThrowException()
    {
      // Arrange
      Request request = null;

      // Act
      var result = async () => await requestRepository.FindRequestByEmailFromRequestAsync(request);

      // Assert
      Assert.That(result, Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public async Task FindRequestByEmailFromRequestAsync_RequestNotExists_ReturnNull()
    {
      // Arrange
      Request request = GenerateRequest();

      // Act
      Request result = await requestRepository.FindRequestByEmailFromRequestAsync(request);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test]
    public async Task FindRequestByPhoneFromRequestAsync_FindSuccessfully()
    {
      // Arrange
      Request request = GenerateRequest();

      studentContext.Requests.Add(request);
      await studentContext.SaveChangesAsync();

      // Act
      Request result = await requestRepository.FindRequestByPhoneFromRequestAsync(request);

      // Assert
      Assert.That(result.Id, Is.EqualTo(request.Id));
    }

    [Test]
    public async Task FindRequestByPhoneFromRequestAsync_RequestIsNull_ThrowException()
    {
      // Arrange
      Request request = null;

      // Act
      var result = async () => await requestRepository.FindRequestByPhoneFromRequestAsync(request);

      // Assert
      Assert.That(result, Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public async Task FindRequestListByStudentGuidAsync_FindSuccessfully()
    {
      // Arrange
      var studentId = Guid.NewGuid();

      Request request = GenerateRequest();
      request.StudentId = studentId;

      Request request2 = GenerateRequest();
      request2.StudentId = studentId;

      studentContext.Requests.Add(request);
      studentContext.Requests.Add(request2);
      await studentContext.SaveChangesAsync();

      // Act
      var result = await requestRepository.FindRequestListByStudentGuidAsync(studentId);

      // Assert
      Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task AddOrderToRequest_AddSuccessfully()
    {
      // Arrange
      Order order = GenerateOrder();

      Request request = GenerateRequest();

      studentContext.Requests.Add(request);
      await studentContext.SaveChangesAsync();

      // Act
      Guid result = await requestRepository.AddOrderToRequest(request.Id, order);

      // Assert
      Assert.That(orderRepository.FindById(order.Id).Result.RequestId, Is.EqualTo(request.Id));
    }

    [Test]
    public async Task AddOrderToRequest_RequestIdNotExists_ThrowException()
    {
      // Arrange
      Order order = GenerateOrder();

      var requestId = Guid.NewGuid();

      // Act
      var result = async () => await requestRepository.AddOrderToRequest(requestId, order);

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

      studentContext.Requests.AddRange(requests);
      await studentContext.SaveChangesAsync();

      int page = 2;
      int pageSize = 2;

      // Act
      var result = await requestRepository.GetRequestsByPage(page, pageSize);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Data, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task GetRequestsByPage_DontHaveNextPage_GetSuccessfully()
    {
      // Arrange
      var requests = new List<Request>();
      for (var i = 0; i < 3; i++)
      {
        requests.Add(GenerateRequest());
      }

      studentContext.Requests.AddRange(requests);
      await studentContext.SaveChangesAsync();

      int page = 1;
      int pageSize = 3;

      // Act
      var result = await requestRepository.GetRequestsByPage(page, pageSize);

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

      studentContext.Requests.AddRange(requests);
      await studentContext.SaveChangesAsync();

      int page = 2;
      int pageSize = 2;

      // Act
      var result = await requestRepository.GetRequestsDTOByPage(page, pageSize);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Data, Has.Count.EqualTo(2));
    }

    private static Request GenerateRequest()
    {
      return new Request()
      {
        Id = Guid.NewGuid(),
        StudentId = Guid.NewGuid(),
        EducationProgramId = Guid.NewGuid(),
        DocumentRiseQualificationId = Guid.NewGuid(),
        DataNumberDogovor = default,
        StatusRequestId = Guid.NewGuid(),
        StudentStatusId = Guid.NewGuid(),
        StatusEntrancExams = default,
        Email = "null",
        Phone = "null",
        Agreement = default
      };
    }

    private static Order GenerateOrder()
    {
      return new Order()
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
        Phone = "null",
        Email = "null",
        IT_Experience = "null",
        ScopeOfActivityLevelOneId = default
      };
    }

  }
}
