namespace Students.Models.ReferenceModels;

/// <summary>
/// Вид программы обучения.
/// </summary>
public class KindEducationProgram
{
  /// <summary>
  /// Идентификатор вида программы обучения.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Название вида программы обучения.
  /// </summary>
  public required string Name { get; set; }
}

