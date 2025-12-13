using Students.Models;

namespace Students.Reports.Models.RosstatModelParts;

public class StudentsInfoRosstatModel
{
  // Не понятно где в модели студента взять присвоена ли квалификация. Это столбец 6.
  
  /// <summary>
  /// Общее количество студентов. Строка 01.
  /// </summary>
  public StudentProgramStats Total { get; set; } =
    new StudentProgramStats(s=> true);
  
  /// <summary>
  /// Работники предприятий и организаций. Строка 02.
  /// </summary>
  public StudentProgramStats Workers { get; set; } =
    new StudentProgramStats(s => s.ScopeOfActivityLevelOne?.NameOfScope == "Работники предприятий и организаций");
  
  /// <summary>
  /// Руководители предприятий и организаций. Срока 03.
  /// </summary>
  public StudentProgramStats EnterpriseHeads { get; set; } =
    new StudentProgramStats(s=>s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители предприятий и организаций");

  /// <summary>
  /// Руководители дошкольных организаций.
  /// </summary>
  public StudentProgramStats HeadsOfPreschool { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители дошкольных образовательных организаций");

  public StudentProgramStats HeadsOfSchool { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители общеобразовательных организаций");
  
  public StudentProgramStats HeadsOfSPOOrg { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители профессиональных образовательных организаций");
  
  public StudentProgramStats HeadsOfHighEducationOrg { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители образовательных организаций ВО");

  public StudentProgramStats HeadsOfAdditionalProfEducationOrg { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители организаций ДПО");
    
  public StudentProgramStats HeadsOfAdditionalEducationOrg { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Руководители организаций дополнительного образования");
  
  public StudentProgramStats PreschoolTeachingStaff { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Педагогические работники дошкольных образовательных организаций");
  
  public StudentProgramStats SchoolTeachingStaff { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Педагогические работники общеобразовательных организаций");
  
  public StudentProgramStats SPOTeachingStaff { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Педагогические работники профессиональных образовательных организаций");
  
  public StudentProgramStats HighEducationOrgTeachingStaff { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Педагогические работники образовательных организаций ВО");
  
  public StudentProgramStats AdditionalProfEducationOrgTeachingStaff { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Педагогические работники профессиональных образовательных организаций");
  
  public StudentProgramStats AdditionalEducationOrgTeachingStaff { get; set; } =
    new StudentProgramStats(s =>
      s.ScopeOfActivityLevelTwo?.NameOfScope == "Педагогические работники организаций дополнительного образования");
}

public class StudentProgramStats
{
  public int Advanced{get;set;}
  public int Retraining{get;set;}
  public int AdvancedModular{get;set;}
  public int RetrainingModular{get;set;}
  public int Woman{get;set;}
  public Func<Student, bool> studentCondition { get; set; }

  public StudentProgramStats(Func<Student, bool> studentCondition)
  {
    this.studentCondition = studentCondition;
  }
}