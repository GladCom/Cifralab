using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Вид выданного документа о квалификации
/// </summary>
public class StudentDocument
{
    /// <summary>
    /// Id документа
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя документа
    /// </summary>
    public string Name { get; set; }
}