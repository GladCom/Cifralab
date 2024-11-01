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

  [Test]
  public async Task GetListEducationProgramOfStudentExists_GetEducationProgramsSuccessfully()
  {
    //Arrange
    const int expected = 3;

    var student = GenerateStudent();
    this._studentContext.Students.Add(student);

    var educationPrograms = new List<EducationProgram>();
    for(var i = 0; i < expected; i++)
    {
      educationPrograms.Add(GenerateEducationProgram());
    }
    this._studentContext.AddRange(educationPrograms);

    var groups = new List<Group>();
    for(var i = 0; i < expected; i++)
    {
      groups.Add(GenerateGroup());
      groups[i].EducationProgramId = educationPrograms[i].Id;
    }
    this._studentContext.AddRange(groups);

    var groupStudent = new List<GroupStudent>();
    for(var i = 0; i < expected; i++)
    {
      groupStudent.Add(new GroupStudent
      {
        StudentsId = student.Id,
        GroupsId = groups[i].Id
      });
    }
    this._studentContext.AddRange(groupStudent);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualEducationPrograms = (await this._educationProgramRepository.GetListEducationProgramsOfStudentExists(student.Id));

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualEducationPrograms, Is.Not.Null);
      var actual = 0;
      foreach(var educationProgram in educationPrograms)
      {

        if(actualEducationPrograms.FirstOrDefault(sg => sg.Id == educationProgram.Id)
           is not null)
          actual++;
      }
      Assert.That(actual, Is.EqualTo(expected));
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
