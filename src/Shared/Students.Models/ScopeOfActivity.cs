using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;

/// <summary>
/// Сфера деятельности
/// </summary>
public class ScopeOfActivity
{
    /// <summary>
    /// Id сферы деятельности
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя сферы деятельности
    /// </summary>
    public string? NameOfScope { get; set; }
    /// <summary>
    /// Уровень сферы деятельности
    /// </summary>
    public ScopeOfActivityLevel Level { get; set; }
}