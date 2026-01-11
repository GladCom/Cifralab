using System.Text.Json.Serialization;

namespace Students.Models;

/// <summary>
/// Группа студентов.
/// </summary>
public class GroupStudent
{
  /// <summary>
  /// Идентификатор студента.
  /// </summary>
  public required Guid StudentId { get; set; }

  /// <summary>
  /// Идентификатор группы.
  /// </summary>
  public required Guid GroupId { get; set; }

  /// <summary>
  /// Идентификатор заявки.
  /// </summary>
  public required Guid RequestId { get; set; }

  /// <summary>
  /// Студент (навигационное свойство).
  /// </summary>
  [JsonIgnore]
  public virtual Student? Student { get; set; }

  /// <summary>
  /// Группа (навигационное свойство).
  /// </summary>
  [JsonIgnore]
  public virtual Group? Group { get; set; }

  /// <summary>
  /// Заявка (навигационное свойство).
  /// </summary>
  [JsonIgnore]
  public virtual Request? Request { get; set; }
}