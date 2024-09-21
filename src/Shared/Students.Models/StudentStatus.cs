using System.ComponentModel.DataAnnotations;

namespace Students.Models;

/// <summary>
/// Статус студента
/// </summary>
public class StudentStatus
{
    /// <summary>
    /// Id статуса
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя статуса
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}