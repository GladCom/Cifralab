namespace Students.Models;

/// <summary>
/// Заявка на обучение
/// </summary>
public class Request
{
    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }
    /// <summary>
    /// Образовательная программа
    /// </summary>
    public EducationProgram EducationProgram { get; set; }
    /// <summary>
    /// Информация о прохождении вступительного испытания
    /// </summary>
    public string EntranceExamination { get; set; }
    /// <summary>
    /// Информация о прохождении собеседования
    /// </summary>
    public string Interview { get; set; }
    /// <summary>
    /// E-mail
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Дата и время подачи заявки
    /// </summary>
    public DateTime CreatedAt { get; set; }
}