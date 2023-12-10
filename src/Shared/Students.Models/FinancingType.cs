using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Тип финансирования
/// </summary>
public class FinancingType
{
    /// <summary>
    /// Id типа финансирования
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя типа финансирования
    /// </summary>
    public string SourceName { get; set; }
}