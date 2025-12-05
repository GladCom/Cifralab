using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using TestAPI.Utilities;

namespace TestAPI.RepositoryTests;

[TestFixture]
public class GenericRepositoryTests
{
  private StudentContext _studentContext;
  private IGenericRepository<Student> _genericRepository;
  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("aa634441-8637-417c-8c00-895753b37cbe"),
    Guid.Parse("c111b3f8-c212-4a40-851a-76817bf004cf"),
    Guid.Parse("8c8801af-5dde-421e-92ba-755b359e2452")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = TestsDepends.GetContext();
    this._genericRepository = TestsDepends.GetGenericRepository<Student>(this._studentContext);
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task Get_Students_GetSuccessfully()
  {
    //Arrange
    const int expected = 3;

    var students = GenerateNewStudents(this._guids.GetRange(0, expected));
    this._studentContext.AddRange(students);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualStudents = (await this._genericRepository.Get()).ToList();

    //Assert
    var actual = 0;
    foreach(var student in students)
    {
      if(actualStudents.FirstOrDefault(sg => sg.Id == student.Id)
          is not null)
        actual++;
    }

    Assert.That(actual, Is.EqualTo(expected));
  }

  [Test]
  public async Task Get_Students_WhereGetSuccessfully()
  {
    //Arrange
    const int expected = 3;

    var students = GenerateNewStudents(this._guids.GetRange(0, expected));
    this._studentContext.AddRange(students);

    await this._studentContext.SaveChangesAsync();
    bool Predicate(Student s)
    {
      return s.Surname == "Тестовый";
    }

    //Act
    var actualStudents = (await this._genericRepository.Get(Predicate)).ToList();

    //Assert
    var actual = 0;
    foreach(var student in students)
    {

      if(actualStudents.FirstOrDefault(sg => sg.Id == student.Id)
         is not null)
        actual++;
    }

    Assert.That(actual, Is.EqualTo(expected));
  }

  [Test]
  public async Task GetOne_Student_GetSuccessfully()
  {
    //Arrange
    const string email = "assdfgg@gmail.com";

    var student = GenerateNewStudent(this._guids[0]);
    student.Email = email;
    this._studentContext.AddRange(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualStudent = await this._genericRepository.GetOne(s => s.Email == email);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualStudent, Is.Not.Null);
      Assert.That(actualStudent?.Email, Is.EqualTo(email));
    });
  }

  [Test]
  public async Task GetOne_Student_NotExistException()
  {
    //Arrange
    const string email = "assdfgg@gmail.com";

    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.AddRange(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualStudent = await this._genericRepository.GetOne(s => s.Email == email);

    //Assert
    Assert.That(actualStudent, Is.Null);
  }

  [Test]
  public async Task FindById_Student_GetSuccessfully()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Add(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualStudent = await this._genericRepository.FindById(student.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualStudent, Is.Not.Null);
      Assert.That(actualStudent?.Id, Is.EqualTo(student.Id));
    });
  }

  [Test]
  public async Task FindById_Id_NotExistsException()
  {
    //Act
    var actualStudent = await this._genericRepository.FindById(Guid.NewGuid());

    //Assert
    Assert.That(actualStudent, Is.Null);
  }

  [Test]
  public async Task Create_NewStudent_AddSuccessfully()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0]);

    //Act
    await this._genericRepository.Create(student);

    //Assert
    var actualStudent = this._studentContext.Students.FirstOrDefault(s => s.Id == student.Id);
    Assert.Multiple(() =>
    {
      Assert.That(actualStudent, Is.Not.Null);
      Assert.That(actualStudent?.Id, Is.EqualTo(student.Id));
    });
  }

  [Test]
  public async Task Create_NewStudentId_IsExistsException()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Add(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var act = async () => await this._genericRepository.Create(student);

    //Assert
    Assert.That(act, Throws.InstanceOf<ArgumentException>());
  }

  [Test]
  public void Create_NewStudent_IsNullException()
  {
    //Act
    var act = async () => await this._genericRepository.Create(null);

    //Assert
    Assert.That(act, Throws.InstanceOf<NullReferenceException>());
  }

  [Test]
  public async Task Update_Student_UpdateSuccessfully()
  {
    //Arrange
    var expected = GenerateNewStudent(this._guids[1]);

    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Add(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualStudent = await this._genericRepository.Update(student.Id, expected);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(actualStudent, Is.Not.Null);
      Assert.That(actualStudent?.Id, Is.EqualTo(expected.Id));
    });
  }

  [Test]
  public async Task Update_Id_IsNotExistsException()
  {
    //Arrange
    var expected = GenerateNewStudent(this._guids[1]);

    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Add(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var actualStudent = await this._genericRepository.Update(Guid.NewGuid(), expected);

    //Assert
    Assert.That(actualStudent, Is.Null);
  }

  [Test]
  public async Task Update_Student_IsNullException()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Add(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    var act = async () => await this._genericRepository.Update(student.Id, null);

    //Assert
    Assert.That(act, Throws.InstanceOf<NullReferenceException>());
  }

  [Test]
  public async Task Remove_Student_RemoveSuccessfully()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0]);
    this._studentContext.Add(student);

    await this._studentContext.SaveChangesAsync();

    //Act
    await this._genericRepository.Remove(student);

    //Assert
    var actualStudent = this._studentContext.Students.FirstOrDefault(s => s.Id == student.Id);
    Assert.That(actualStudent, Is.Null);
  }

  [Test]
  public void Remove_Student_IsNotExistsException()
  {
    //Arrange
    var student = GenerateNewStudent(this._guids[0]);

    //Act
    var act = async () => await this._genericRepository.Remove(student);

    //Assert
    Assert.That(act, Throws.InstanceOf<DbUpdateConcurrencyException>());
  }

  [Test]
  public void Remove_Student_IsNullException()
  {
    //Act
    var act = async () => await this._genericRepository.Remove(null);

    //Assert
    Assert.That(act, Throws.InstanceOf<ArgumentNullException>());
  }

  private static List<Student> GenerateNewStudents(List<Guid> id)
  {
    return id.Select(GenerateNewStudent).ToList();
  }

  private static Student GenerateNewStudent(Guid id)
  {
    return new Student
    {
      Id = id,
      Surname = "Тестовый",
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
