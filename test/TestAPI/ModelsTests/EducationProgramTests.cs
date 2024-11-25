using Students.Models;
using Students.Models.ReferenceModels;

namespace TestAPI.ModelsTests;

[TestFixture]
public class EducationProgramTests
{
  [Test]
  public void NewEducationProgram()
  {
    var educationProgram = new EducationProgram
    {
      FinancingType = new FinancingType()
      {
        Id = Guid.NewGuid(),
        SourceName = "Тест"
      },
      KindDocumentRiseQualification = new KindDocumentRiseQualification()
      {
        Id = Guid.NewGuid(),
        Name = "Тест"
      },
      KindEducationProgram = new KindEducationProgram()
      {
          Id = Guid.NewGuid(),
          Name = "Тест"
      },
      Cost = 0,
      HoursCount = 0,
      EducationFormId = default,
      KindDocumentRiseQualificationId = default,
      KindEducationProgramId = default,
      IsModularProgram = false,
      FinancingTypeId = default,
      IsCollegeProgram = false,
      IsArchive = false,
      IsNetworkProgram = false,
      IsDOTProgram = false,
      IsFullDOTProgram = false,
      Name = string.Empty,
      QualificationName = string.Empty
    };

    Assert.IsNotNull(educationProgram);
  }
}
