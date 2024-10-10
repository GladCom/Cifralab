using System.Text.Json.Serialization;

namespace Students.Models
{
  /// <summary>
  /// Группа студентов (данный класс должен умереть)
  /// </summary>
  public class GroupStudent
  {
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public required Guid StudentsId { get; set; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public required Guid GroupsId { get; set; }

    /// <summary>
    /// Студент (навигационное свойство)
    /// </summary>
    [JsonIgnore]
    public virtual Student Student { get; set; } = null!;

    /// <summary>
    /// Группа (навигационное свойство)
    /// </summary>
    [JsonIgnore]
    public virtual Group Group { get; set; } = null!;
  }
}
