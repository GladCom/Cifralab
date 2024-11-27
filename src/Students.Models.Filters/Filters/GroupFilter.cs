namespace Students.Models.Filters.Filters;

public class GroupFilter : Filter<Group>
{
  /// <summary>
  /// Идентификатор студента.
  /// </summary>
  public Guid? StudentId { get; set; }

  /// <summary>
  ///   Нижняя граница начала периода.
  /// </summary>
  public DateOnly? StartDateMin { get; set; }

  /// <summary>
  ///   Верхняя граница начала периода.
  /// </summary>
  public DateOnly? StartDateMax { get; set; }

  /// <summary>
  ///   Нижняя граница конца периода.
  /// </summary>
  public DateOnly? EndDateMin { get; set; }

  /// <summary>
  ///   Верхняя граница конца периода.
  /// </summary>
  public DateOnly? EndDateMax { get; set; }

  /// <summary>
  ///   Группы.
  /// </summary>
  public List<string>? Names { get; set; }

  /// <summary>
  /// Предикат по которому осуществляется фильтрация.
  /// </summary>
  /// <returns>Предикат.</returns>
  public override Predicate<Group> GetFilterPredicate()
  {
    return x => 
      (!this.StartDateMin.HasValue || x.StartDate >= this.StartDateMin) && 
      (!this.StartDateMax.HasValue || x.StartDate <= this.StartDateMax) &&
      (!this.EndDateMax.HasValue || x.EndDate <= this.EndDateMax) &&
      (!this.EndDateMin.HasValue || x.EndDate >= this.EndDateMin) &&
      (this.Names is null || this.Names.Contains(x.Name!)) && 
      (!this.StudentId.HasValue || x.GroupStudent.Any(gs => gs.StudentId == this.StudentId));
  }
}
