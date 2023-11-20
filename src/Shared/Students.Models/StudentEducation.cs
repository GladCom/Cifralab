namespace Students.Models;

/// <summary>
/// Образование студента
/// </summary>
public class StudentEducation
{
    /// <summary>
    /// Id образования
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя образования
    /// </summary>
    public string Name { get; set; }
}