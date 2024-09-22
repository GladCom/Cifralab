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
    public required string Name { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public required string Birthday { get; set; }
    /// <summary>
    /// Уровень образования
    /// </summary>
    [Required]
    public required string EducationLevel { get; set; }
    /// <summary>
    /// Направление образования
    /// </summary>
    [Required]
    public required string Education { get; set; }
    /// <summary>
    /// Опыт работы в IT
    /// </summary>
    [Required]
    public required string IT_Experience { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    [Required]
    public required string Address { get; set; }
    /// <summary>
    /// Мобильный телефон
    /// </summary>
    [Required]
    public required string Phone { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    public required string Email { get; set; }
    /// <summary>
    /// Согласие на обработку персональных данных
    /// </summary>
    [Required]
    public required string Agreement { get; set; }
    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    [Required]
    public required string tranid { get; set; }
    /// <summary>
    /// Идентификатор формы
    /// </summary>
    [Required]
    public required string formid { get; set; }
}