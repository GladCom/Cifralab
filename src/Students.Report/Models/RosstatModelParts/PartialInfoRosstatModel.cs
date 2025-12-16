using Students.Models;

namespace Students.Reports.Models.RosstatModelParts;

public abstract class PartialInfoRosstatModel
{
  /// <summary>
  /// Название рода занятий.
  /// </summary>
  private string? NameOfScope { get; set; }
  
  /// <summary>
  /// Ограничение по роду занятий.
  /// </summary>
  public  Func<Student, bool>? ScopeOfActivityCondition { get; private set; }
  
  /// <summary>
  /// Имя образовательной программы.
  /// </summary>
  private string? EducationProgramName { get; set; }
  
  /// <summary>
  /// Ограничение группы по образовательной программе.
  /// </summary>
  public Func<Group, bool>? EducationProgramCondition { get; private set; }
  
  /// <summary>
  /// Установить ограничение по роду занятий.
  /// </summary>
  /// <param name="nameOfScope">Название рода занятий.</param>
  public void SetNameOfScopeCondition(string nameOfScope)
  {
    this.NameOfScope = nameOfScope;
    this.ScopeOfActivityCondition = s => s.ScopeOfActivityLevelTwo?.NameOfScope == nameOfScope ||
                                 s.ScopeOfActivityLevelOne?.NameOfScope == nameOfScope;    
  }

  /// <summary>
  /// Установить ограничение по типу образовательной программы.
  /// </summary>
  /// <param name="nameOfEducationProgram">Название типа образовательной программы.</param>
  public void SetEducationProgramCondition(string nameOfEducationProgram)
  {
    this.EducationProgramCondition = g => g.EducationProgram?.KindEducationProgram?.Name == nameOfEducationProgram;
  }
}