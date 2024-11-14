namespace Students.Models.Filters.Filters;
public class StudentFilter : Filter<Student>
{
  public override Predicate<Student> GetFilterPredicate()
  {
    throw new NotImplementedException();
  }
}
