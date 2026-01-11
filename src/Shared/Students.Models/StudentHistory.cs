using System.Text.Json.Serialization;

namespace Students.Models;

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
    public string? Family { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Дата изменения.
    /// </summary>
    public required DateTime ChangeDate { get; set; }

    /// <summary>
    /// Студент.
    /// </summary>
    [JsonIgnore]
    public Student? Student { get; set; }
}

