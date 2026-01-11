namespace Students.Models.Filters.Filters;

public class EducationProgramFilter : Filter<EducationProgram>
{
  /// <summary>
  /// Архивная программа.
  /// </summary>
  public bool? IsArchive { get; set; }

  /// <summary>
  /// Архивная программа.
  /// </summary>
  public Guid? StudentId { get; set; }

  public override Predicate<EducationProgram> GetFilterPredicate()
  {
    return x => (!this.IsArchive.HasValue || this.IsArchive == x.IsArchive) &&
                (!this.StudentId.HasValue || x.Requests.Any(r => r.StudentId == this.StudentId));
  }
}
