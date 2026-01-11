using Students.Models.ReferenceModels;

namespace Students.Models.Filters.Filters;
public class KindOrderFilter : Filter<KindOrder>
{
  public override Predicate<KindOrder> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
