namespace Students.Models.ReferenceModels;

/// <summary>
/// Вид документа повышения квалификации
/// </summary>
public class KindDocumentRiseQualification
{
  /// <summary>
  /// Id программы
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Имя программы
  /// </summary>
  public required string Name { get; set; }
}