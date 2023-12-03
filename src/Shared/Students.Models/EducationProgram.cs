namespace Students.Models;

/// <summary>
/// Образовательная программа
/// </summary>
public class EducationProgram
{
    /// <summary>
    /// Id программы
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование программы
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Количество часов
    /// </summary>
    public int HoursCount { get; set; }
    /// <summary>
    /// Id Вида программы
    /// </summary>
    public Guid EducationTypeId { get; set; }
    /// <summary>
    /// Вид программы
    /// </summary>
    public EducationType? EducationType { get; set; }
    /// <summary>
    /// Id Формы обучения
    /// </summary>
    public Guid EducationFormId { get; set; }
    /// <summary>
    /// Форма обучения
    /// </summary>
    public EducationForm? EducationForm { get; set; }
    /// <summary>
    /// Сетевая форма
    /// </summary>
    public bool IsNetworkProgram { get; set; }
    /// <summary>
    /// Применение ДОТ
    /// </summary>
    public bool IsDOTProgram { get; set; }
    /// <summary>
    /// Модульная программа
    /// </summary>
    public bool IsModularProgram { get; set; }
    /// <summary>
    /// Id ВЭД программы
    /// </summary>
    public Guid? FEAProgramId { get; set; }
    /// <summary>
    /// ВЭД программы
    /// </summary>
    public FEAProgram? FEAProgram { get; set; }
    /// <summary>
    /// Обязательно наличие ВО
    /// </summary>
    public bool IsCollegeProgram { get; set; }
}