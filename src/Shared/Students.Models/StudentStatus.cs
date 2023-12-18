using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Статус студента
/// </summary>
public class StudentStatus
{
    /// <summary>
    /// Id статуса
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя статуса
    /// </summary>
    public string Name { get; set; }
}