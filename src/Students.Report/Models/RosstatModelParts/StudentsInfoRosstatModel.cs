using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.Reports.Models.RosstatModelParts;

public class StudentsInfoRosstatModel<T> where T : PartialInfoRosstatModel, new()
{
  public List<T> Categories { get; set; } = new ();

  /// <summary>
  /// Добавить в модель сведений категории по занятости.
  /// </summary>
  /// <param name="scopeOfActivities"></param>
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

  public void AddEducationalProgramCategory(List<EducationProgram> educationalPrograms)
  {
    if (typeof(T) != typeof(EducationProgram))
    {
      throw new InvalidOperationException("Данное действие можно вызвать только для типа EducationProgram");
    }
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