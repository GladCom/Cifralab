using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.Reports.Models.RosstatModelParts;

public class StudentsInfoRosstatModel<T> where T : PartialInfoRosstatModel, new()
{
  public List<T> Categories { get; set; } = new ();

  /// <summary>
  /// Добавить в модель сведений категорию, ограниченную по занятости.
  /// </summary>
  /// <param name="scopeOfActivities">Имя категории занятости.</param>
  public void AddScopeOfActivityCategory(List<ScopeOfActivity> scopeOfActivities)
  {
    foreach (var scopeOfActivity in scopeOfActivities)
    {
      if (scopeOfActivity.NameOfScope != null)
      {
        var newCategory = new T();
        newCategory.SetNameOfScopeCondition(scopeOfActivity.NameOfScope);
        this.Categories.Add(newCategory);
      }
    }
  }

  /// <summary>
  /// Добавить в модель сведений категорию, ограниченную по образовательной программе.
  /// </summary>
  /// <param name="educationalPrograms"></param>
  public void AddEducationalProgramCategory(List<EducationProgram> educationalPrograms)
  {
    foreach (var educationalProgram in educationalPrograms)
    {
      if (educationalProgram.Name != null)
      {
        var newCategory = new T();
        newCategory.SetEducationProgramCondition(educationalProgram.Name);
        this.Categories.Add(newCategory);
      }
    }
  }
}