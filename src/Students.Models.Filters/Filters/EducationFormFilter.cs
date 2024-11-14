using Students.Models.ReferenceModels;

namespace Students.Models.Filters.Filters;
public class EducationFormFilter : Filter<EducationForm>
{
  public override Predicate<EducationForm> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
