using Group = Students.Models.Group;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI
{
  [TestFixture]
  public class StudentRepositoryTests
  {
    private StudentContext studentContext;
    private StudentRepository studentRepository;
    private GroupStudentRepository groupStudentRepository;

    [SetUp]
    public void SetUp()
    {
      studentContext = new InMemoryContext();
      studentContext.Students.RemoveRange(studentContext.Students.ToList());
      studentContext.Groups.RemoveRange(studentContext.Groups.ToList());
      groupStudentRepository = new GroupStudentRepository(studentContext);
      studentRepository = new StudentRepository(studentContext, groupStudentRepository);
    }

    [TearDown]
    public void TearDown()
    {
      studentContext.Dispose();
    }

    [Test]
    public async Task GetStudentsByPage_GetStudentsSuccessfully()
    {
      //Arrange
      Student student = GenerateStudent();
      Student student2 = GenerateStudent();

      int page = 1;
      int pageSize = 3;

      studentContext.Students.Add(student);
      studentContext.Students.Add(student2);
      await studentContext.SaveChangesAsync();

      // Act
      var result = studentRepository.GetStudentsByPage(page, pageSize);

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
      Student student = GenerateStudent();
      Group group1 = GenerateGroup();
      Group group2 = GenerateGroup();

      studentContext.Students.Add(student);
      studentContext.Groups.Add(group1);
      studentContext.Groups.Add(group2);
      studentContext.GroupStudent.Add(new GroupStudent { StudentsId = student.Id, GroupsId = group1.Id });
      studentContext.GroupStudent.Add(new GroupStudent { StudentsId = student.Id, GroupsId = group2.Id });
      await studentContext.SaveChangesAsync();

      //Act
      var groups = await studentRepository.GetListGroupsOfStudentExists(student.Id);

      //Assert
      Assert.That(groups.ToList(), Has.Count.EqualTo(2));
    }

    [Test]
    public async Task AddStudentToGroup_AddSuccessfully()
    {
      //Arrange
      Student student = GenerateStudent();

      Group group = GenerateGroup();

      studentContext.Students.Add(student);
      studentContext.Groups.Add(group);
      await studentContext.SaveChangesAsync();

      //Act
      Guid result = await studentRepository.AddStudentToGroup(student.Id, group.Id);

      //Assert
      Assert.That(studentContext.GroupStudent.FirstOrDefault(sg => sg.GroupsId == group.Id && sg.StudentsId == student.Id), 
        Is.Not.Null);
    }

    [Test]
    public async Task AddStudentToGroup_GroupIdNotExists_ThrowException()
    {
      //Arrange
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      var emptyGroupGuid = Guid.Empty;

      // Act
      var result = async () => await studentRepository.AddStudentToGroup(student.Id, emptyGroupGuid);

      //Assert
      Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public async Task AddStudentToGroup_StudentIdNotExists_ThrowException()
    {
      //Arrange
      Group group = GenerateGroup();

      studentContext.Groups.Add(group);
      await studentContext.SaveChangesAsync();

      var emptyStudentGuid = Guid.Empty;

      // Act
      var result = async () => await studentRepository.AddStudentToGroup(emptyStudentGuid, group.Id);

      //Assert
      Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public async Task FindById_FindSuccessfully()
    {
      //Arrange
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      //Act
      Student result = await studentRepository.FindById(student.Id);

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
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      var newStudentGiud = Guid.NewGuid();

      //Act
      Student result = await studentRepository.FindById(newStudentGiud);

      //Assert
      Assert.That(result, Is.Null);
    }

    [Test]
    public async Task FindByPhone_FindSuccessfully()
    {
      //Arrange
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      //Act
      Student result = await studentRepository.FindByPhone(student.Phone);

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
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      var phone = "89022834692";

      //Act
      Student result = await studentRepository.FindByPhone(phone);

      //Assert
      Assert.That(result, Is.Null);
    }

    [Test]
    public async Task FindByEmail_FindSuccessfully()
    {
      //Arrange
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      //Act
      Student result = await studentRepository.FindByEmail(student.Email);

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
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      var email = "adv@aeqb.wefq";

      //Act
      Student result = await studentRepository.FindByEmail(email);

      //Assert
      Assert.That(result, Is.Null);
    }

    [Test]
    public async Task FindByPhoneAndEmail_FindSuccessfully()
    {
      //Arrange
      Student student = GenerateStudent();

      studentContext.Students.Add(student);
      await studentContext.SaveChangesAsync();

      //Act
      Student result = await studentRepository.FindByPhoneAndEmail(student.Phone, student.Email);

      //Assert
      Assert.Multiple(() =>
      {
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(student.Id));
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
        Phone = "null",
        Email = "null",
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
  }
}
