namespace Students.Models;

/// <summary>
/// Статус студента
/// </summary>
public class StudentStatus
{
  /// <summary>
  /// Id статуса
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Имя статуса
  /// </summary>
  public required string Name { get; set; }
}