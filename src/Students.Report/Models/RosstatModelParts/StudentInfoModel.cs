using Students.Models;

namespace Students.Reports.Models.RosstatModelParts;

public abstract class StudentInfoModel
{
  public string NameOfScope { get; set; }
  public Func<Student, bool> studentCondition { get; private set; }
  public void SetNameOfScope(string nameOfScope)
  {
    this.NameOfScope = nameOfScope;
    this.studentCondition = s => s.ScopeOfActivityLevelOne?.NameOfScope == nameOfScope ||
                                 s.ScopeOfActivityLevelTwo?.NameOfScope == nameOfScope;    
  }
}