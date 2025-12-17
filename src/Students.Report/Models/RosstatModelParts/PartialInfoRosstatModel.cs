using Students.Models;
using Students.Models.Enums;

namespace Students.Reports.Models.RosstatModelParts;

public abstract class PartialInfoRosstatModel
{
  /// <summary>
  /// Наименование категории.
  /// </summary>
  public string Name { get; set; } = string.Empty;
  /// <summary>
  /// Ограничение по роду занятий.
  /// </summary>
  public Func<Student, bool>? ScopeOfActivityCondition { get; private set; }
  
  /// <summary>
  /// Ограничение группы по образовательной программе.
  /// </summary>
  public Func<Group, bool>? EducationProgramCondition { get; private set; }
  
  /// <summary>
  /// Ограничение группы по полу студентов.
  /// </summary>
  public Func<Student, bool>? SexCondition { get; private set; } = s => true;
  
  /// <summary>
  /// Установить ограничение по роду занятий.
  /// </summary>
  /// <param name="nameOfScope">Название рода занятий.</param>
  public void SetNameOfScopeCondition(string nameOfScope)
  {
    this.ScopeOfActivityCondition = s => s.ScopeOfActivityLevelTwo?.NameOfScope == nameOfScope ||
                                 s.ScopeOfActivityLevelOne?.NameOfScope == nameOfScope;
    this.Name += nameOfScope;
  }

  /// <summary>
  /// Установить ограничение по типу образовательной программы.
  /// </summary>
  /// <param name="nameOfEducationProgram">Название типа образовательной программы.</param>
  public void SetEducationProgramCondition(string nameOfKindEducationProgram)
  {
    this.EducationProgramCondition = g => g.EducationProgram?.KindEducationProgram?.Name == nameOfKindEducationProgram;
    this.Name += nameOfKindEducationProgram;
  }
  
  /// <summary>
  /// Установить ограничение по типу образовательной программы.
  /// </summary>
  /// <param name="nameOfEducationProgram">Название типа образовательной программы.</param>
  public void SetOnlyWomanCondition(bool isOnlyWoman)
  {
    this.SexCondition = s => s.Sex == SexHuman.Woman;
    this.Name += "_womans";
  }
}