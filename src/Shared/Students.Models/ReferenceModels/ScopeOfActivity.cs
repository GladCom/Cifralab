using Students.Models.Enums;
using System.Text.Json.Serialization;

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

  /// <summary>
  /// Id родительской сферы деятельности (если есть).
  /// </summary>
  public Guid? ScopeOfActivityParentId { get; set; }

  /// <summary>
  /// Родительская сфера деятельности.
  /// </summary>
  [JsonIgnore]
  public ScopeOfActivity? ScopeOfActivityParent { get; set; }
}