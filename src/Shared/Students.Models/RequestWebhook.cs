using System.ComponentModel.DataAnnotations;

namespace Students.Models;

/// <summary>
/// Вебхук для обработки формы заявки на обучение, сюда добавить недостающие данные от минцифры типа nullable
/// </summary>
public class RequestWebhook
{
    /// <summary>
    /// ФИО
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public string Birthday { get; set; } = string.Empty;
    /// <summary>
    /// Уровень образования
    /// </summary>
    [Required]
    public string EducationLevel { get; set; } = string.Empty;
    /// <summary>
    /// Направление образования
    /// </summary>
    [Required]
    public string Education { get; set; } = string.Empty;
    /// <summary>
    /// Опыт работы в IT
    /// </summary>
    [Required]
    public string IT_Experience { get; set; } = string.Empty;
    /// <summary>
    /// Адрес
    /// </summary>
    [Required]
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Мобильный телефон
    /// </summary>
    [Required]
    public string Phone { get; set; } = string.Empty;
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// Согласие на обработку персональных данных
    /// </summary>
    [Required]
    public string Agreement { get; set; } = string.Empty;
    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    [Required]
    public string tranid { get; set; } = string.Empty;
    /// <summary>
    /// Идентификатор формы
    /// </summary>
    [Required]
    public string formid { get; set; } = string.Empty;
}