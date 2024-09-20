namespace Students.Models;

/// <summary>
/// Вебхук для обработки формы заявки на обучение, сюда добавить недостающие данные от минцифры типа nullable
/// </summary>
public class RequestWebhook
{
    /// <summary>
    /// ФИО
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public string Birthday { get; set; }
    /// <summary>
    /// Уровень образования
    /// </summary>
    public string EducationLevel { get; set; }
    /// <summary>
    /// Направление образования
    /// </summary>
    public string Education { get; set; }
    /// <summary>
    /// Опыт работы в IT
    /// </summary>
    public string IT_Experience { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Мобильный телефон
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Согласие на обработку персональных данных
    /// </summary>
    public string Agreement { get; set; }
    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    public string tranid { get; set; }
    /// <summary>
    /// Идентификатор формы
    /// </summary>
    public string formid { get; set; }
}