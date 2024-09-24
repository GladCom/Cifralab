using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    public string? Name { get; set; }
    /// <summary>
    /// Стоимость обучения
    /// </summary>
    public double Cost { get; set; }
    /// <summary>
    /// Количество часов
    /// </summary>
    public int HoursCount { get; set; }
    /// <summary>
    /// Id Формы обучения
    /// </summary>
    public Guid? EducationFormId { get; set; }
    /// <summary>
    /// Форма обучения
    /// </summary>
    [JsonIgnore]
    [Required]
    public EducationForm? EducationForm { get; set; }
    /// <summary>
    /// Вид документа повышения квалификации
    /// </summary>
    public Guid? KindDocumentRiseQualificationId { get; set; }
    /// <summary>
    /// Вид документа повышения квалификации
    /// </summary>
    [JsonIgnore]
    [Required]
    public KindDocumentRiseQualification? KindDocumentRiseQualification { get; set; }
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
    [JsonIgnore]
    [Required]
    public FEAProgram? FEAProgram { get; set; }
    /// <summary>
    /// Id источника финансирования
    /// </summary>
    public Guid? FinancingTypeId { get; set; }

    /// <summary>
    /// Источник финансирования
    /// </summary>
    [JsonIgnore]
    [Required]
    public FinancingType? FinancingType { get; set; }

    /// <summary>
    /// Группы обучения
    /// </summary>
    public List<Group>? Groups { get; set; }


    //Вот это наследие от прежних разрабов - похоже не нужно
    /// <summary>
    /// Обязательно наличие ВО
    /// </summary>
    public bool IsCollegeProgram { get; set; }

    /// <summary>
    /// Признак программы в архиве
    /// </summary>
    public bool IsArchive { get; set; }
}