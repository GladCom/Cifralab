using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.Reports.Models.RosstatModelParts;

public class StudentsInfoRosstatModel
{
  // Не понятно где в модели студента взять присвоена ли квалификация. Это столбец 6.
  
  public List<StudentProgramStats> Categories { get; set; } = new List<StudentProgramStats>();

  public StudentsInfoRosstatModel(List<ScopeOfActivity> scopeOfActivities)
  {
    foreach (var scopeOfActivity in scopeOfActivities)
    {
      if (scopeOfActivity.NameOfScope != null)
        this.Categories.Add(new StudentProgramStats(scopeOfActivity.NameOfScope));
    }
    
  }
}

public class StudentProgramStats
{
  public string NameOfScope { get; set; }
  public int Advanced{get;set;}
  public int Retraining{get;set;}
  public int AdvancedModular{get;set;}
  public int RetrainingModular{get;set;}
  public int Woman{get;set;}
  public Func<Student, bool> studentCondition { get; } 

  public StudentProgramStats(string nameOfScope)
  {
    this.NameOfScope = nameOfScope;
    this.studentCondition = s => s.ScopeOfActivityLevelOne?.NameOfScope == nameOfScope ||
                                 s.ScopeOfActivityLevelTwo?.NameOfScope == nameOfScope;
  }
}