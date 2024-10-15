using Students.Models.Enums;

namespace Students.Models.ReferenceModels;

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
    public required ScopeOfActivityLevel Level { get; set; }
}