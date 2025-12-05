using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using TestAPI.Utilities;
using Group = Students.Models.Group;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class GroupRepositoryTests
{
  private StudentContext _studentContext;
  private IGroupRepository _groupRepository;

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._groupRepository = TestsDepends.GetGroupRepository(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_Students_AddSuccessfully()
  {
    //Arrange
    const int expected = 3;

    var students = GenerateNewStudents(expected);
    this._studentContext.AddRange(students);

    var requests = GenerateNewRequests(students!);
    this._studentContext.AddRange(requests);

    var group = GenerateNewGroup();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var badRequests = await this._groupRepository.AddStudentsToGroupByRequest(requests.Select(r => r.Id).ToList(), group.Id);

    //Assert
    var actual = 0;
    for(var i = 0; i < students.Count; i++)
    {
      if(this._studentContext.GroupStudent.FirstOrDefault(sg =>
            sg.GroupId == group.Id && sg.StudentId == students[i].Id && sg.RequestId == requests[i].Id)
          is not null)
        actual++;
    }

    Assert.Multiple(() =>
    {
      Assert.That(badRequests!.Count(), Is.EqualTo(0));
      Assert.That(actual, Is.EqualTo(expected));
    });
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_RequestsIsNull_Exception()
  {
    //Arrange
    List<Guid>? requests = null;
    var group = GenerateNewGroup();

    this._studentContext.Add(group);
    await this._studentContext.SaveChangesAsync();

    //Act
    var act = async () => await this._groupRepository.AddStudentsToGroupByRequest(requests, group.Id);

    //Assert
    Assert.That(act, Throws.InstanceOf<NullReferenceException>());
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_IdOfANonExistentGroup_Exception()
  {
    //Arrange
    var students = GenerateNewStudents(3);
    this._studentContext.AddRange(students);

    var requests = GenerateNewRequests(students!);
    this._studentContext.AddRange(requests);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actual = await this._groupRepository.AddStudentsToGroupByRequest(requests.Select(r => r.Id).ToList(), Guid.Empty);

    //Assert
    Assert.That(actual, Is.Null);
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_IdStudentInRequest_IsNullException()
  {
    //Arrange

    var request = GenerateRequest(null);
    this._studentContext.Add(request);

    var group = GenerateNewGroup();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var badRequests = await this._groupRepository.AddStudentsToGroupByRequest(new List<Guid> { request.Id }, group.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(badRequests!.Count(), Is.EqualTo(1));
      Assert.That(this._studentContext.GroupStudent.Count(), Is.EqualTo(0));
    });
  }

  [Test]
  public async Task AddStudentsToGroupByRequest_GroupAndRequest_HasDifferentEducationProgramsException()
  {
    //Arrange

    var student = GenerateNewStudent();
    this._studentContext.Add(student);

    var request = GenerateRequest(student.Id);
    request.EducationProgramId = Guid.NewGuid();
    this._studentContext.Add(request);

    var group = GenerateNewGroup();
    group.EducationProgramId = Guid.NewGuid();
    this._studentContext.Add(group);

    await this._studentContext.SaveChangesAsync();

    //Act
    var badRequests = await this._groupRepository.AddStudentsToGroupByRequest(new List<Guid> { request.Id }, group.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(badRequests!.Count(), Is.EqualTo(1));
      Assert.That(this._studentContext.GroupStudent.Count(), Is.EqualTo(0));
    });
  }

  private static List<Student> GenerateNewStudents(int count)
  {
    var students = new List<Student>();
    for(var i = 0; i < count; i++)
    {
      students.Add(GenerateNewStudent());
    }
    return students;
  }

  private static List<Group> GenerateNewGroups(int count)
  {
    var groups = new List<Group>();
    for(var i = 0; i < count; i++)
    {
      groups.Add(GenerateNewGroup());
    }
    return groups;
  }

  private static List<Request> GenerateNewRequests(Guid studentId, int count)
  {
    var requests = new List<Request>();
    for(var i = 0; i < count; i++)
    {
      requests.Add(GenerateRequest(studentId));
    }
    return requests;
  }

  private static List<Request> GenerateNewRequests(List<Student?> students)
  {
    return students.Select(student => GenerateRequest(student?.Id)).ToList();
  }

  private static List<GroupStudent> GenerateNewGroupsStudent(List<Group> groups, List<Request> requests)
  {
    return groups.Select((t, i) => GenerateNewGroupStudent(requests[i].StudentId!.Value, t.Id, requests[i].Id)).ToList();
  }

  private static Student GenerateNewStudent()
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

  private static Request GenerateRequest(Guid? studentId)
  {
    return new Request
    {
      Id = Guid.NewGuid(),
      StudentId = studentId,
      EducationProgramId = Guid.Empty,
      Phone = "+7 (123) 456-78-90",
      Email = "test@gmail.com",
      Agreement = default
    };
  }

  private static Group GenerateNewGroup()
  {
    return new Group
    {
      Id = Guid.NewGuid(),
      EducationProgramId = Guid.Empty,
      StartDate = default,
      EndDate = default
    };
  }

  private static GroupStudent GenerateNewGroupStudent(Guid studentsId, Guid groupsId, Guid requestId)
  {
    return new GroupStudent
    {
      StudentId = studentsId,
      GroupId = groupsId,
      RequestId = requestId
    };
  }
}
