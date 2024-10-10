namespace Students.Models;

/// <summary>
/// Форма обучения
/// </summary>
public class EducationForm
{
    /// <summary>
    /// Id формы
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя формы обучения
    /// </summary>
    public string? Name { get; set; }
}