namespace Students.Models;

/// <summary>
/// Вид образовательной программы
/// </summary>
public class EducationType
{
    /// <summary>
    /// Id программы
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя программы
    /// </summary>
    public string Name { get; set; }
}