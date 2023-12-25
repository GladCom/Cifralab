using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Образование студента
/// </summary>
public class StudentEducation
{
    /// <summary>
    /// Id образования
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя образования
    /// </summary>
    public string Name { get; set; }
}