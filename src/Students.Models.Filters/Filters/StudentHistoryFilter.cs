namespace Students.Models.Filters.Filters;

public class StudentHistoryFilter : Filter<StudentHistory>
{
  /// <summary>
  /// Id студента.
  /// </summary>
  public Guid? StudentId { get; set; }

  public override Predicate<StudentHistory> GetFilterPredicate()
  {
    return x => !this.StudentId.HasValue || this.StudentId == x.StudentId;
  }
}
