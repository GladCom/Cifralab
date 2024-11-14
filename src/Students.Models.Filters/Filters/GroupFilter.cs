namespace Students.Models.Filters.Filters;

public class GroupFilter : Filter<Group>
{
  /// <summary>
  /// Идентификатор студента.
  /// </summary>
  public Guid? StudentId { get; set; }

  public override Predicate<Group> GetFilterPredicate()
  {
    return x => !this.StudentId.HasValue || x.GroupStudent.Any(gs => gs.StudentId == this.StudentId);
  }
}
