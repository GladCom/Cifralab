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
    this._educationProgramController = new EducationProgramController(new EducationProgramRepository(this._studentContext), new TestLogger<EducationProgram>())
    {
      ControllerContext = new ControllerContext
      {
        HttpContext = new DefaultHttpContext()
      }
    };
    this._studentContext.EducationPrograms.RemoveRange(this._studentContext.Set<EducationProgram>());
    this._studentContext.SaveChanges();
  }

  [TearDown]
  public void TearDown()
  {
    this._studentContext.Dispose();
  }

  [TestCase(false)]
  [TestCase(true)]
  public async Task MoveToArchiveOrBack_EducationProgramSetIsArchive_Ok(bool value)
  {
    //Arrange
    var educationProgram = GenerateNewEducationProgram(this._guids[0]);
    educationProgram.IsArchive = value;
    this._studentContext.EducationPrograms.Add(educationProgram);
    await this._studentContext.SaveChangesAsync();

    //Act
    var result = await this._educationProgramController.MoveToArchiveOrBack(this._guids[0]);
    var okResult = result as ObjectResult;
    var foundEducationProgram = this._studentContext.EducationPrograms.FirstOrDefault();

    // assert
    Assert.Multiple(() =>
    {
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
      Assert.That(foundEducationProgram, Is.Not.Null);
      Assert.That(foundEducationProgram.IsArchive, Is.EqualTo(!value));
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
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
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