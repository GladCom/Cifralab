using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Controllers;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

namespace TestAPI.ControllersTests;

[TestFixture]
public class EducationProgramControllerTests
{
  private StudentContext _studentContext;
  private GenericRepository<EducationProgram> _genericRepository;
  private EducationProgramRepository _educationProgramRepository;
  private EducationProgramController _educationProgramController;

  private readonly List<Guid> _guids = new()
  {
    Guid.Parse("aa634441-8637-417c-8c00-895753b37cbe"),
    Guid.Parse("c111b3f8-c212-4a40-851a-76817bf004cf"),
    Guid.Parse("8c8801af-5dde-421e-92ba-755b359e2452")
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
  public async Task Get_EducationProgramsArchive_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    educationProgram.IsArchive = true;
    this._studentContext.EducationPrograms.Add(educationProgram);
    var educationProgram2 = GenerateNewEducationProgram(this._guids[1]);
    educationProgram2.IsArchive = false;
    this._studentContext.EducationPrograms.Add(educationProgram2);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._educationProgramController.Get(true);
    var okResult = result as ObjectResult;

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
      Assert.AreEqual((okResult.Value as IEnumerable<EducationProgram>).Count(), 1);
      Assert.AreEqual((okResult.Value as IEnumerable<EducationProgram>).First().IsArchive, true);
    });
  }

  [Test]
  public async Task Get_EducationProgramsNotArchive_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    educationProgram.IsArchive = true;
    this._studentContext.EducationPrograms.Add(educationProgram);
    var educationProgram2 = GenerateNewEducationProgram(this._guids[1]);
    educationProgram2.IsArchive = false;
    this._studentContext.EducationPrograms.Add(educationProgram2);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._educationProgramController.Get(false);
    var okResult = result as ObjectResult;

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
      Assert.AreEqual((okResult.Value as IEnumerable<EducationProgram>).Count(), 1);
      Assert.AreEqual((okResult.Value as IEnumerable<EducationProgram>).First().IsArchive, false);
    });
  }

  [Test]
  public async Task Get_EducationProgramsArchiveNotFound_Ok()
  {
    //Act
    var result = await this._educationProgramController.Get(true);
    var okResult = result as ObjectResult;

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
      Assert.AreEqual((okResult.Value as IEnumerable<EducationProgram>).Count(), 0);
    });
  }

  [Test]
  public async Task Get_EducationProgramsNotArchiveNotFound_Ok()
  {
    //Act
    var result = await this._educationProgramController.Get(false);
    var okResult = result as ObjectResult;

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
      Assert.AreEqual((okResult.Value as IEnumerable<EducationProgram>).Count(), 0);
    });
  }

  [Test]
  public async Task MoveToArchiveOrBack_EducationProgramSetIsArchive_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    educationProgram.IsArchive = false;
    this._studentContext.EducationPrograms.Add(educationProgram);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._educationProgramController.MoveToArchiveOrBack(this._guids[0]);
    var okResult = result as ObjectResult;
    var foundEducationProgram = this._studentContext.EducationPrograms.FirstOrDefault();

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
      Assert.IsNotNull(foundEducationProgram);
      Assert.AreEqual(foundEducationProgram.IsArchive, true);
    });
  }

  [Test]
  public async Task MoveToArchiveOrBack_EducationProgramSetIsNotArchive_Ok()
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    educationProgram.IsArchive = true;
    this._studentContext.EducationPrograms.Add(educationProgram);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._educationProgramController.MoveToArchiveOrBack(this._guids[0]);
    var okResult = result as ObjectResult;
    var foundEducationProgram = this._studentContext.EducationPrograms.FirstOrDefault();

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
      Assert.IsNotNull(foundEducationProgram);
      Assert.AreEqual(foundEducationProgram.IsArchive, false);
    });
  }

  [Test]
  public async Task MoveToArchiveOrBack_EducationProgram_NotFound()
  {
    //Act
    var result = await this._educationProgramController.MoveToArchiveOrBack(this._guids[0]);
    var okResult = result as ObjectResult;

    // assert
    Assert.Multiple(() =>
    {
      Assert.IsNotNull(okResult);
      Assert.AreEqual(StatusCodes.Status404NotFound, okResult.StatusCode);
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