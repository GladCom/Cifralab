namespace Students.Models;

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
    public string? Name { get; set; }
}