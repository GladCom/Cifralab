using Students.Models.ReferenceModels;

namespace Students.Models.Filters.Filters;
public class StatusRequestFilter : Filter<StatusRequest>
{
  public override Predicate<StatusRequest> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
