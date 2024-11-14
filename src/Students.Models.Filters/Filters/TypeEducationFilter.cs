using Students.Models.ReferenceModels;

namespace Students.Models.Filters.Filters;
public class TypeEducationFilter : Filter<TypeEducation>
{
  public override Predicate<TypeEducation> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
