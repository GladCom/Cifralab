using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;
using Group = Students.Models.Group;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class StudentRepositoryTests
{
  private StudentContext _studentContext;
  private StudentRepository _studentRepository;
  private GroupStudentRepository _groupStudentRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._studentContext.Students.RemoveRange(this._studentContext.Students.ToList());
    this._studentContext.Groups.RemoveRange(this._studentContext.Groups.ToList());
    this._studentContext.Requests.RemoveRange(this._studentContext.Requests.ToList());
    this._groupStudentRepository = new GroupStudentRepository(this._studentContext);
    this._studentRepository = new StudentRepository(this._studentContext, this._groupStudentRepository);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task GetStudentsByPage_GetStudentsSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();
    var student2 = GenerateStudent();

    var page = 1;
    var pageSize = 3;

    this._studentContext.Students.Add(student);
    this._studentContext.Students.Add(student2);
    await this._studentContext.SaveChangesAsync();

    // Act
    var result = this._studentRepository.GetStudentsByPage(page, pageSize);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Result.Data.ToList(), Has.Count.EqualTo(2));
      Assert.That(result.Result.HasNext, Is.False);
    });
  }

  [Test]
  public async Task GetListGroupsOfStudentExists_GetStudentsSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();
    var group1 = GenerateGroup();
    var group2 = GenerateGroup();

    this._studentContext.Students.Add(student);
    this._studentContext.Groups.Add(group1);
    this._studentContext.Groups.Add(group2);
    this._studentContext.GroupStudent.Add(new GroupStudent { StudentsId = student.Id, GroupsId = group1.Id });
    this._studentContext.GroupStudent.Add(new GroupStudent { StudentsId = student.Id, GroupsId = group2.Id });
    await this._studentContext.SaveChangesAsync();

    //Act
    var groups = await this._studentRepository.GetListGroupsOfStudentExists(student.Id);

    //Assert
    Assert.That(groups.ToList(), Has.Count.EqualTo(2));
  }

  [Test]
  public async Task AddStudentToGroup_AddSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();

    var group = GenerateGroup();

    this._studentContext.Students.Add(student);
    this._studentContext.Groups.Add(group);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._studentRepository.AddStudentToGroup(student.Id, group.Id);

    //Assert
    Assert.That(this._studentContext.GroupStudent.FirstOrDefault(sg => sg.GroupsId == group.Id && sg.StudentsId == student.Id),
      Is.Not.Null);
  }

  [Test]
  public async Task AddStudentToGroup_GroupIdNotExists_ThrowException()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    var emptyGroupGuid = Guid.Empty;

    // Act
    var result = async () => await this._studentRepository.AddStudentToGroup(student.Id, emptyGroupGuid);

    //Assert
    Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
  }

  [Test]
  public async Task AddStudentToGroup_StudentIdNotExists_ThrowException()
  {
    //Arrange
    var group = GenerateGroup();

    this._studentContext.Groups.Add(group);
    await this._studentContext.SaveChangesAsync();

    var emptyStudentGuid = Guid.Empty;

    // Act
    var result = async () => await this._studentRepository.AddStudentToGroup(emptyStudentGuid, group.Id);

    //Assert
    Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
  }

  [Test]
  public async Task FindById_FindSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._studentRepository.FindById(student.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Id, Is.EqualTo(student.Id));
    });
  }

  [Test]
  public async Task FindById_IdNotExists_ReturnNull()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    var newStudentGiud = Guid.NewGuid();

    //Act
    var result = await this._studentRepository.FindById(newStudentGiud);

    //Assert
    Assert.That(result, Is.Null);
  }

  [Test]
  public async Task FindByPhone_FindSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._studentRepository.FindByPhone(student.Phone);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Id, Is.EqualTo(student.Id));
    });
  }

  [Test]
  public async Task FindByPhone_PhoneNotExists_ReturnNull()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    var phone = "89022834692";

    //Act
    var result = await this._studentRepository.FindByPhone(phone);

    //Assert
    Assert.That(result, Is.Null);
  }

  [Test]
  public async Task FindByEmail_FindSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._studentRepository.FindByEmail(student.Email);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Id, Is.EqualTo(student.Id));
    });
  }

  [Test]
  public async Task FindByEmail_EmailNotExists_ReturnNull()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    var email = "adv@aeqb.wefq";

    //Act
    var result = await this._studentRepository.FindByEmail(email);

    //Assert
    Assert.That(result, Is.Null);
  }

  [Test]
  public async Task FindByPhoneAndEmail_FindSuccessfully()
  {
    //Arrange
    var student = GenerateStudent();

    this._studentContext.Students.Add(student);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._studentRepository.FindByPhoneAndEmail(student.Phone, student.Email);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Id, Is.EqualTo(student.Id));
    });
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
    var actualEducationPrograms = (await this._studentRepository.GetListEducationProgramsOfStudentExists(student.Id));

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
      Assert.AreEqual(expected, actual);
    });
  }

  [Test]
  public async Task GetListRequestsOfStudentExists_GetRequestsSuccessfully()
  {
    //Arrange
    const int expected = 3;

    var student = GenerateStudent();
    this._studentContext.Students.Add(student);

    var requests = new List<Request>();
    for(var i = 0; i < expected; i++)
    {
      requests.Add(GenerateRequest(student.Id));
    }
    this._studentContext.AddRange(requests);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualRequests = (await this._studentRepository.GetListRequestsOfStudentExists(student.Id));

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualRequests, Is.Not.Null);
      var actual = 0;
      foreach(var request in requests)
      {

        if(actualRequests.FirstOrDefault(sg => sg.Id == request.Id)
            is not null)
          actual++;
      }
      Assert.AreEqual(expected, actual);
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
}