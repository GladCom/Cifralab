using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    [JsonIgnore]
    public EducationType? EducationType { get; set; }
    /// <summary>
    /// Id Формы обучения
    /// </summary>
    public Guid EducationFormId { get; set; }
    /// <summary>
    /// Форма обучения
    /// </summary>
    [JsonIgnore]
    public EducationForm? EducationForm { get; set; }

    Тут есть вопрос к аналитикам эту часть они вынесли в группу обучения
    ....................
    /// <summary>
    /// Сетевая форма
    /// </summary>
    public bool IsNetworkProgram { get; set; }
    /// <summary>
    /// Применение ДОТ
    /// </summary>
    public bool IsDOTProgram { get; set; }
    .......................................................
    
    Модульная программа вообще boolean
    /// <summary>
    /// Ид Модульная программа
    /// </summary>
    public Guid? ModularProgramId { get; set; }

    /// <summary>
    /// Модульная программа
    /// </summary>
    [JsonIgnore]
    public ModularProgram ModularProgram { get; set; }

    /// <summary>
    /// Id ВЭД программы
    /// </summary>
    public Guid? FEAProgramId { get; set; }
    /// <summary>
    /// ВЭД программы
    /// </summary>
    [JsonIgnore]
    public FEAProgram? FEAProgram { get; set; }

    /// <summary>
    /// Id источника финансирования
    /// </summary>
    public Guid? FinancingTypeId { get; set; }

    /// <summary>
    /// Источник финансирования
    /// </summary>
    [JsonIgnore]
    public FinancingType FinancingType { get; set; }

    /// <summary>
    /// Группы обучения
    /// </summary>
    public List<Group> Groups { get; set; }


    ??????????????????
    /// <summary>
    /// Обязательно наличие ВО
    /// </summary>
    public bool IsCollegeProgram { get; set; }
}