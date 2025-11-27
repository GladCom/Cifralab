namespace Students.Models.Filters.Filters;
public class StudentFilter : Filter<Student>
{
  public string? Family { get; set; }
  
  public override Predicate<Student> GetFilterPredicate()
  {
    return
      x => (string.IsNullOrEmpty((this.Family)) || this.Family.ToLower() == x.Family.ToLower());
  }
}
