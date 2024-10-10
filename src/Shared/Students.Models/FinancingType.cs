namespace Students.Models;

/// <summary>
/// Тип финансирования
/// </summary>
public class FinancingType
{
  /// <summary>
  /// Id типа финансирования
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Имя типа финансирования
  /// </summary>
  public string? SourceName { get; set; }
}