using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Filters.Filters;
using Students.Models.ReferenceModels;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class RequestRepositoryTests
{
  private StudentContext _studentContext;
  private RequestRepository _requestRepository;
  private OrderRepository _orderRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentContext.Students.RemoveRange(this._studentContext.Students.ToList());
    this._studentContext.Requests.RemoveRange(this._studentContext.Requests.ToList());
    this._studentContext.Orders.RemoveRange(this._studentContext.Orders.ToList());
    this._orderRepository = new OrderRepository(this._studentContext);
    this._requestRepository = new RequestRepository(this._studentContext,
      new OrderRepository(this._studentContext),
      new StudentRepository(this._studentContext, new StudentHistoryRepository(this._studentContext)),
      new GenericRepository<StatusRequest>(this._studentContext),
      new GenericRepository<PhantomStudent>(this._studentContext));
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
  public async Task AddOrderToRequest_RequestIdNotExists_ThrowException()
  {
    // Arrange
    var order = GenerateOrder();

    var requestId = Guid.NewGuid();

    // Act
    var result = await this._requestRepository.AddOrderToRequest(requestId, order);

    // Assert
    Assert.That(result, Is.Null);
  }

  [Test]
  public async Task GetRequestsDTOByPage_GetSuccessfully()
  {
    // Arrange
    var requests = new List<Request>();
    for(var i = 0; i < 5; i++)
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

  [Test]
  public async Task GetFiltered_ReturnRequest_byStatusAndProgram()
  {
    // Arrange
    var request = GenerateRequestWithProgramAndStatus();

    var requestFilter = new RequestFilter { EducationProgramId = request.EducationProgram?.Id, StatusRequestId = request.Status?.Id };

    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = await this._requestRepository.GetFiltered(requestFilter);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result.Count, Is.EqualTo(1));
      Assert.IsTrue(result.All(x => requestFilter.GetFilterPredicate()(x)));
    });
  }

  [Test]
  public async Task GetFiltered_ReturnRequest_byProgramEducation()
  {
    // Arrange
    var request = GenerateRequestWithProgramAndStatus();
    var requestFilter = new RequestFilter { EducationProgramId = request.EducationProgram?.Id };
    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = await this._requestRepository.GetFiltered(requestFilter);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result.Count, Is.EqualTo(1));
      Assert.That(result.All(x => requestFilter.GetFilterPredicate()(x)));
    });
  }

  [Test]
  public async Task GetFiltered_ReturnRequest_byStatus()
  {
    // Arrange
    var request = GenerateRequestWithProgramAndStatus();
    var requestFilter = new RequestFilter { StatusRequestId = request.Status?.Id };
    this._studentContext.Requests.Add(request);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = await this._requestRepository.GetFiltered(requestFilter);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result.Count, Is.EqualTo(1));
      Assert.IsTrue(result.All(x => requestFilter.GetFilterPredicate()(x)));
    });
  }

  [Test]
  public async Task GetFiltered_ReturnRequest_withEmptyRequestFilter()
  {
    // Arrange
    var requestFilter = new RequestFilter();

    // Act
    var result = await this._requestRepository.GetFiltered(requestFilter);

    //Assert
    Assert.That(result.Count, Is.Not.EqualTo(0));
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

  private static Request GenerateRequestWithProgramAndStatus()
  {
    var status = GenerateStatusRequest();
    var program = GenerateEducationProgram();

    return new Request()
    {
      Id = Guid.NewGuid(),
      StudentId = Guid.NewGuid(),
      EducationProgram = program,
      DocumentRiseQualificationId = Guid.NewGuid(),
      DataNumberDogovor = default,
      Status = status,
      StudentStatusId = Guid.NewGuid(),
      StatusEntrancExams = default,
      Phone = "+7 (123) 456-78-90",
      Email = "test@gmail.com",
      Agreement = default
    };
  }

  private static EducationProgram GenerateEducationProgram()
  {
    return new EducationProgram
    {
      Id = Guid.NewGuid(),
      Name = "AnnihilatorTests",
      EducationFormId = Guid.NewGuid(),
      FinancingTypeId = Guid.NewGuid(),
      KindDocumentRiseQualificationId = Guid.NewGuid(),
      Cost = 2,
      IsArchive = false,
      HoursCount = 0,
      IsCollegeProgram = true,
      IsDOTProgram = true,
      IsFullDOTProgram = true,
      IsModularProgram = true,
      IsNetworkProgram = true,
    };
  }

  private static StatusRequest GenerateStatusRequest()
  {
    return new StatusRequest()
    {
      Id = Guid.NewGuid(),
      Name = "AEZAKMI"
    };
  }
}