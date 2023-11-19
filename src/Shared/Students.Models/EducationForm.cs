using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Форма обучения
/// </summary>
public class EducationForm
{
    /// <summary>
    /// Id формы
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя формы обучения
    /// </summary>
    public string Name { get; set; }
}