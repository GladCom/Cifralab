namespace Students.Models;

/// <summary>
/// Вид выданного документа о квалификации
/// </summary>
public class StudentDocument
{
    /// <summary>
    /// Id документа
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя документа
    /// </summary>
    public string Name { get; set; }
}