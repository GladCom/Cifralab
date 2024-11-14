using System.Text.Json.Serialization;

namespace Students.Models.ReferenceModels;

/// <summary>
/// История изменений студента.
/// </summary>
public class StudentHistory
{
  /// <summary>
  /// Id истории изменений.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Id студента.
  /// </summary>
  public required Guid StudentId { get; set; }

  /// <summary>
  /// Фамилия.
  /// </summary>
  public required string Family { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Дата изменения.
  /// </summary>
  public DateTime? ChangeDate { get; set; }

  /// <summary>
  /// Студент.
  /// </summary>
  [JsonIgnore]
  public Student? Student { get; set; }
}

