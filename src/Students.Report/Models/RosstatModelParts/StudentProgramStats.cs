using Students.Models;

namespace Students.Reports.Models.RosstatModelParts;

public class StudentProgramStats : StudentInfoModel
{
  // Не понятно где в модели студента взять присвоена ли квалификация. Это столбец 6.
  public string NameOfScope { get; set; }
  public int Advanced{get;set;}
  public int Retraining{get;set;}
  public int AdvancedModular{get;set;}
  public int RetrainingModular{get;set;}
  public int Woman{get;set;}
}