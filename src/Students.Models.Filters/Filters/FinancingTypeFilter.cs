using Students.Models.ReferenceModels;

namespace Students.Models.Filters.Filters;
public class FinancingTypeFilter : Filter<FinancingType>
{
  public override Predicate<FinancingType> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
