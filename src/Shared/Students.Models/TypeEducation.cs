namespace Students.Models;

/// <summary>
/// Образование студента
/// </summary>
public class TypeEducation
{
  /// <summary>
  /// Id образования
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Имя образования
  /// </summary>
  public required string Name { get; set; }
}