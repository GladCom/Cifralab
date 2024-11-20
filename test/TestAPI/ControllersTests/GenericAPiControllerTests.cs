using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI.ControllersTests;

[TestFixture]
public class GenericAPiControllerTests
{
  private StudentContext _studentContext;
  private TestGenericAPiController _testController;

  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("aa634441-8637-417c-8c00-895753b37cbe"),
    Guid.Parse("c111b3f8-c212-4a40-851a-76817bf004cf")
  };

  [SetUp]
  public void SetUp()
  {
    this._studentContext = new InMemoryContext();
    this._testController = new TestGenericAPiController(new GenericRepository<EducationProgram>(this._studentContext), new TestLogger<EducationProgram>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
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
    await this._testController.Post(GenerateNewEducationProgram(this._guids[0]));
    await this._testController.Post(GenerateNewEducationProgram(this._guids[1]));

    //Act
    var result = await this._testController.ListAll();

    // assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    });
  }

  [Test]
  public async Task ListAll_Count_Ok()
  {
    //Arrange
    await this._testController.Post(GenerateNewEducationProgram(this._guids[0]));
    await this._testController.Post(GenerateNewEducationProgram(this._guids[1]));

    //Act
    var result = await this._testController.ListAll();

    // Assert
    var okResult = result as ObjectResult;
    var list = okResult?.Value as IEnumerable<EducationProgram>;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(list?.Count(), Is.EqualTo(2));
    });
  }

  [Test]
  public async Task ListAll_NullResult_Ok()
  {
    //Act
    var result = await this._testController.ListAll();

    // Assert
    var okResult = result as ObjectResult;
    var list = okResult?.Value as IEnumerable<EducationProgram>;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(list?.Count(), Is.EqualTo(0));
    });
  }

  [Test]
  public async Task Get_ById_Ok()
  {
    //Arrange
    await this._testController.Post(GenerateNewEducationProgram(this._guids[0]));
    await this._testController.Post(GenerateNewEducationProgram(this._guids[1]));

    //Act
    var result = await this._testController.Get(this._guids[0]);

    // Assert
    var okResult = result as ObjectResult;
    var value = okResult?.Value as EducationProgram;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(value?.Id, Is.EqualTo(this._guids[0]));
    });
  }

  [Test]
  public async Task Get_ByNullId_NotFound()
  {
    //Act
    var result = await this._testController.Get(Guid.Empty);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Get_ById_NotFound()
  {
    //Act
    var result = await this._testController.Get(this._guids[0]);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Post_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);

    //Act
    var resultPost = await this._testController.Post(educationProgram);

    // Assert
    var okResultPost = resultPost as ObjectResult;
    var resultGet = await this._testController.Get(this._guids[0]);
    var okResultGet = resultGet as ObjectResult;
    var foundEducationProgram = okResultGet?.Value as EducationProgram;

    Assert.Multiple(() =>
    {
      Assert.That(okResultPost?.Value, Is.Not.Null);
      Assert.That(okResultPost?.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
      Assert.That(okResultGet?.Value, Is.Not.Null);
      Assert.That(okResultGet?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(foundEducationProgram?.Id, Is.EqualTo(this._guids[0]));
    });
  }

  [Test]
  public async Task Post_ExistId_InternalServerError()
  {
    //Arrange
    var educationProgram1 = GenerateNewEducationProgram(this._guids[0]);
    await this._testController.Post(educationProgram1);
    var educationProgram2 = GenerateNewEducationProgram(this._guids[0]);

    //Act
    var result = await this._testController.Post(educationProgram2);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
    });
  }

  [Test]
  public async Task Put_Ok()
  {
    //Arrange
    await this._testController.Post(GenerateNewEducationProgram(this._guids[0]));
    var educationProgramEdited = GenerateNewEducationProgram(this._guids[0]);
    var newName = "Новое имя программы";
    educationProgramEdited.Name = newName;

    //Act
    var result = await this._testController.Put(this._guids[0], educationProgramEdited);

    // Assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That((okResult?.Value as EducationProgram)?.Id, Is.EqualTo(this._guids[0]));
      Assert.That((okResult?.Value as EducationProgram)?.Name, Is.EqualTo(newName));
    });
  }

  [Test]
  public async Task Put_FromOther_Ok()
  {
    //Arrange
    await this._testController.Post(GenerateNewEducationProgram(this._guids[0]));
    var educationProgramOther = GenerateNewEducationProgram(this._guids[1]);
    var newName = "Имя другой программы";
    educationProgramOther.Name = newName;

    //Act
    var result = await this._testController.Put(this._guids[0], educationProgramOther);

    // Assert
    var okResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That((okResult?.Value as EducationProgram)?.Id, Is.EqualTo(this._guids[0]));
      Assert.That((okResult?.Value as EducationProgram)?.Name, Is.EqualTo(newName));
    });
  }

  [Test]
  public async Task Put_FromNull_InternalServerError()
  {
    //Arrange
    await this._testController.Post(GenerateNewEducationProgram(this._guids[0]));
    EducationProgram? educationProgram = null;

    //Act
    var result = await this._testController.Put(this._guids[0], educationProgram);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
    });
  }

  [Test]
  public async Task Put_NotExisted_NotFound()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);

    //Act
    var result = await this._testController.Put(this._guids[0], educationProgram);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
      Assert.That(errorResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Delete_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    await this._testController.Post(educationProgram);

    //Act
    var result = await this._testController.Delete(this._guids[0]);

    // Assert
    var okResult = result as ObjectResult;
    var foundResult = await this._testController.Get(this._guids[0]);
    var okFoundResult = foundResult as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(okResult?.Value, Is.Not.Null);
      Assert.That(okResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(okFoundResult?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
    });
  }

  [Test]
  public async Task Delete_NotFound()
  {
    //Act
    var result = await this._testController.Delete(this._guids[0]);

    // Assert
    var errorResult = result as ObjectResult;

    Assert.Multiple(() =>
    {
      Assert.That(errorResult?.Value, Is.Not.Null);
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

  private class TestGenericAPiController : GenericAPiController<EducationProgram>
  {
    #region Поля и свойства
    private readonly ILogger<EducationProgram> _logger;
    private readonly IGenericRepository<EducationProgram> _genericRepository;
    #endregion

    #region Конструкторы
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="repository">Общий репозиторий.</param>
    /// <param name="logger">Логгер.</param>
    public TestGenericAPiController(IGenericRepository<EducationProgram> repository, ILogger<EducationProgram> logger) :
      base(repository, logger)
    {
      this._logger = logger;
      this._genericRepository = repository;
    }
    #endregion
  }
}