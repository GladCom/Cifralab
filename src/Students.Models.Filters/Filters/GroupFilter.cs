using System.Text.Json.Serialization;

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
    ///
    public List<string>? GroupNames { get; set; }

    /// <summary>
    /// Предикат по которому осуществляется фильтрация.
    /// </summary>
    /// <returns>Предикат.</returns>
    public override Predicate<Group> GetFilterPredicate()
    {
        // сделал так для удобства дебага
        return group =>
        {
            DateOnly groupStart = group.StartDate;
            DateOnly groupEnd = group.EndDate;

            bool checkStartMin = !this.StartDateMin.HasValue || groupStart >= this.StartDateMin.Value;
            bool checkStartMax = !this.StartDateMax.HasValue || groupStart <= this.StartDateMax.Value;

            bool checkEndMin = !this.EndDateMin.HasValue || groupEnd >= this.EndDateMin.Value;
            bool checkEndMax = !this.EndDateMax.HasValue || groupEnd <= this.EndDateMax.Value;


            bool checkName = (this.GroupNames == null) ||
                             (group.Name != null && this.GroupNames.Contains(group.Id.ToString()));


            bool checkStudent = !this.StudentId.HasValue ||
                                (group.GroupStudent != null &&
                                 group.GroupStudent.Any(gs => gs.StudentId == this.StudentId));


            return checkStartMin &&
                   checkStartMax &&
                   checkEndMin &&
                   checkEndMax &&
                   checkName &&
                   checkStudent;
        };
    }
}
