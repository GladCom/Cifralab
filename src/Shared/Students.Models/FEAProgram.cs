using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// ВЭД программы
/// </summary>
public class FEAProgram
{
    /// <summary>
    /// Id ВЭД
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя ВЭД
    /// </summary>
    public string? Name { get; set; }
}