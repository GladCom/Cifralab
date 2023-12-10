using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Вид образовательной программы
/// </summary>
public class EducationType
{
    /// <summary>
    /// Id программы
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя программы
    /// </summary>
    public string Name { get; set; }
}