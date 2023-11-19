namespace Students.Models;

/// <summary>
/// Группа обучения
/// </summary>
public class Group
{
    /// <summary>
    /// Id группы
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя группы
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Образорвательная программа
    /// </summary>
    public EducationProgram EducationProgram { get; set; }
    /// <summary>
    /// Начало обучения
    /// </summary>
    public DateOnly StartDate { get; set; }
    /// <summary>
    /// Конец обучения
    /// </summary>
    public DateOnly EndDate { get; set; }
    /// <summary>
    /// Студенты
    /// </summary>
    public List<Student> Students { get; set; }
}