using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI.ControllersTests;

[TestFixture]
public class GenericAPiControllerTests
{
  private StudentContext _studentContext;
  private GenericRepository<EducationProgram> _genericRepository;
  private EducationProgramRepository _educationProgramRepository;
  private EducationProgramController _educationProgramController;

  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("aa634441-8637-417c-8c00-895753b37cbe"),
    Guid.Parse("c111b3f8-c212-4a40-851a-76817bf004cf")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._genericRepository = new GenericRepository<EducationProgram>(this._studentContext);
    this._educationProgramRepository = new EducationProgramRepository(this._studentContext);
    this._educationProgramController = new EducationProgramController(_genericRepository, _educationProgramRepository, new TestLogger<EducationProgram>());
    this._educationProgramController.ControllerContext = new ControllerContext();
    this._educationProgramController.ControllerContext.HttpContext = new DefaultHttpContext();
    this._studentContext.EducationPrograms.RemoveRange(this._studentContext.Set<EducationProgram>());
    this._studentContext.SaveChangesAsync();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [Test]
  public async Task ListAll_Ok()
  {
    //Arrange
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[0]));
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[1]));

    //Act
    var result = await this._educationProgramController.ListAll();
    var okResult = result as ObjectResult;

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    });
  }

  [Test]
  public async Task ListAll_Count_Ok()
  {
    //Arrange
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[0]));
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[1]));

    //Act
    var result = await this._educationProgramController.ListAll();
    var okResult = result as ObjectResult;
    var list = okResult?.Value as IEnumerable<EducationProgram>;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult?.Value);
      Assert.That(2, Is.EqualTo(list?.Count()));
    });
  }

  [Test]
  public async Task ListAll_NullResult_Ok()
  {
    //Act
    var result = await this._educationProgramController.ListAll();
    var okResult = result as ObjectResult;
    var list = okResult?.Value as IEnumerable<EducationProgram>;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult?.Value);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(0, Is.EqualTo(list?.Count()));
    });
  }

  [Test]
  public async Task Get_ById_Ok()
  {
    //Arrange
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[0]));
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[1]));

    //Act
    var result = await this._educationProgramController.Get(this._guids[0]);
    var okResult = result as ObjectResult;
    var value = okResult?.Value as EducationProgram;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult?.Value);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(this._guids[0], Is.EqualTo(value?.Id));
    });
  }

  [Test]
  public async Task Get_ByNullId_NotFound()
  {
    //Act
    var result = await this._educationProgramController.Get(Guid.Empty);
    var errorResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(errorResult?.Value);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Get_ById_NotFound()
  {
    //Act
    var result = await this._educationProgramController.Get(this._guids[0]);
    var errorResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(errorResult?.Value);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Post_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);

    //Act
    var resultPost = await this._educationProgramController.Post(educationProgram);
    var okResultPost = resultPost as ObjectResult;
    var resultGet = await this._educationProgramController.Get(this._guids[0]);
    var okResultGet = resultGet as ObjectResult;
    var foundEducationProgram = okResultGet?.Value as EducationProgram;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResultPost?.Value);
      Assert.That(okResultPost?.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
      Assert.IsNotNull(okResultGet?.Value);
      Assert.That(okResultGet?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(foundEducationProgram?.Id, Is.EqualTo(this._guids[0]));
    });
  }

  [Test]
  public async Task Post_ExistId_InternalServerError()
  {
    //Arrange
    var educationProgram1 = GenerateNewEducationProgram(_guids[0]);
    await this._educationProgramController.Post(educationProgram1);
    var educationProgram2 = GenerateNewEducationProgram(this._guids[0]);

    //Act
    var result = await this._educationProgramController.Post(educationProgram2);
    var errorResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(errorResult?.Value);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
    });
  }

  [Test]
  public async Task Put_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[0]));
    var educationProgramEdited = GenerateNewEducationProgram(this._guids[0]);
    var newName = "Новое имя программы";
    educationProgramEdited.Name = newName;

    //Act
    var result = await this._educationProgramController.Put(this._guids[0], educationProgramEdited);
    var okResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult?.Value);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(this._guids[0], Is.EqualTo((okResult?.Value as EducationProgram)?.Id));
      Assert.That(newName, Is.EqualTo((okResult?.Value as EducationProgram)?.Name));
    });
  }

  [Test]
  public async Task Put_FromOther_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[0]));
    var educationProgramOther = GenerateNewEducationProgram(this._guids[1]);
    var newName = "Имя другой программы";
    educationProgramOther.Name = newName;

    //Act
    var result = await this._educationProgramController.Put(this._guids[0], educationProgramOther);
    var okResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult?.Value);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(this._guids[0], Is.EqualTo((okResult?.Value as EducationProgram)?.Id));
      Assert.That(newName, Is.EqualTo((okResult?.Value as EducationProgram)?.Name));
    });
  }

  [Test]
  public async Task Put_FromNull_InternalServerError()
  {
    //Arrange
    await this._educationProgramController.Post(GenerateNewEducationProgram(this._guids[0]));
    EducationProgram educationProgram = null;

    //Act
    var result = await this._educationProgramController.Put(this._guids[0], educationProgram);
    var errorResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(errorResult?.Value);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
    });
  }

  [Test]
  public async Task Put_NotExisted_NotFound()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);

    //Act
    var result = await this._educationProgramController.Put(this._guids[0], educationProgram);
    var errorResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(errorResult?.Value);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Delete_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    await this._educationProgramController.Post(educationProgram);

    //Act
    var result = await this._educationProgramController.Delete(this._guids[0]);
    var okResult = result as ObjectResult;
    var foundResult = await this._educationProgramController.Get(this._guids[0]);
    var okFoundResult = foundResult as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult?.Value);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okFoundResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Delete_notFound()
  {
    //Act
    var result = await this._educationProgramController.Delete(this._guids[0]);
    var errorResult = result as ObjectResult;

    // Assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(errorResult?.Value);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }


  private static EducationProgram GenerateNewEducationProgram(Guid id)
  {
    return new EducationProgram
    {
      Id = id,
      Name = default,
      HoursCount = default,
      EducationFormId = default,
      IsModularProgram = false,
      FEAProgramId = default,
      IsCollegeProgram = false,
      Cost = default,
      FinancingTypeId = default,
      KindDocumentRiseQualificationId = default,
      IsArchive = false,
      IsNetworkProgram = false,
      IsDOTProgram = false,
      IsFullDOTProgram = false,
    };
  }
}