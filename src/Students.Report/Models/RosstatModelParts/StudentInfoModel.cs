using Students.Models;

namespace Students.Reports.Models.RosstatModelParts;

public abstract class StudentInfoModel
{
  public string NameOfScope { get; set; }
  public Func<Student, bool> studentCondition { get; private set; }
  public void SetNameOfScope(string nameOfScope)
  {
    this.NameOfScope = nameOfScope;
    this.studentCondition = s => s.ScopeOfActivityLevelTwo?.NameOfScope == nameOfScope ||
                                 s.ScopeOfActivityLevelOne?.NameOfScope == nameOfScope;    
  }
}