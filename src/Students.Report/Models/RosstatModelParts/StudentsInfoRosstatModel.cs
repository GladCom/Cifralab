using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.Reports.Models.RosstatModelParts;

public class StudentsInfoRosstatModel<T> where T : StudentInfoModel, new()
{
  public List<T> Categories { get; set; } = new ();

  public StudentsInfoRosstatModel(List<ScopeOfActivity> scopeOfActivities)
  {
    foreach (var scopeOfActivity in scopeOfActivities)
    {
      if (scopeOfActivity.NameOfScope != null)
      {
        var newCategory = new T();
        newCategory.SetNameOfScope(scopeOfActivity.NameOfScope);
        this.Categories.Add(newCategory);
      }
    }
  }
}