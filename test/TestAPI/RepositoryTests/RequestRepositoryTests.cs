using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.ReferenceModels;
using TestAPI.Utilities;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class RequestRepositoryTests
{
  private StudentContext _studentContext;
  private IRequestRepository _requestRepository;
  private IOrderRepository _orderRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._orderRepository = TestsDepends.GetOrderRepository(this._studentContext);
    this._requestRepository = TestsDepends.GetRequestRepository(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
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
    Assert.That((await this._orderRepository.FindById(order.Id)).RequestId, Is.EqualTo(request.Id));
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

    const int page = 2;
    const int pageSize = 2;

    // Act
    var result = await this._requestRepository.GetRequestDTOByPageFilteredSorted(page, pageSize, "StudentFullName", true, "{}");

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
      KindEducationProgramId = Guid.NewGuid(),
      Cost = 2,
      IsArchive = false,
      HoursCount = 0,
      IsCollegeProgram = true,
      IsDOTProgram = true,
      IsFullDOTProgram = true,
      IsModularProgram = true,
      IsNetworkProgram = true,
      QualificationName = string.Empty
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