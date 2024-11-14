using Students.Models.ReferenceModels;

namespace Students.Models.Filters.Filters;
public class StudentStatusFilter : Filter<StudentStatus>
{
  public override Predicate<StudentStatus> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
