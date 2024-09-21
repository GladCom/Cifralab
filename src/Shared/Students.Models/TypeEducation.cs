using System.ComponentModel.DataAnnotations;
namespace Students.Models;

/// <summary>
/// Образование студента
/// </summary>
public class TypeEducation
{
    /// <summary>
    /// Id образования
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя образования
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}