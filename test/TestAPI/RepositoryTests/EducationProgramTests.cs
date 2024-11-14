using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Group = Students.Models.Group;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class EducationProgramTests
{
  private StudentContext _studentContext;
  private EducationProgramRepository _educationProgramRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentContext.Students.RemoveRange(this._studentContext.Students.ToList());
    this._studentContext.Groups.RemoveRange(this._studentContext.Groups.ToList());
    this._studentContext.Requests.RemoveRange(this._studentContext.Requests.ToList());
    this._studentContext.EducationPrograms.RemoveRange(this._studentContext.EducationPrograms.ToList());
    this._educationProgramRepository = new EducationProgramRepository(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
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

  private static EducationProgram GenerateEducationProgram()
  {
    return new EducationProgram
    {
      Id = Guid.NewGuid(),
      Cost = 0,
      HoursCount = 0,
      EducationFormId = default,
      KindDocumentRiseQualificationId = default,
      IsModularProgram = false,
      FinancingTypeId = default,
      IsCollegeProgram = false,
      IsArchive = false,
      IsNetworkProgram = false,
      IsDOTProgram = false,
      IsFullDOTProgram = false,
    };
  }
}
