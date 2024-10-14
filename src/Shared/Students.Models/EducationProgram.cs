using System.Text.Json.Serialization;

namespace Students.Models;

/// <summary>
/// Образовательная программа.
/// </summary>
public class EducationProgram
{
  /// <summary>
  /// Id программы.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Наименование программы.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Стоимость обучения.
  /// </summary>
  public required double Cost { get; set; }

  /// <summary>
  /// Количество часов.
  /// </summary>
  public required int HoursCount { get; set; }

  /// <summary>
  /// Id Формы обучения.
  /// </summary>
  public required Guid EducationFormId { get; set; }

  /// <summary>
  /// Вид документа повышения квалификации.
  /// </summary>
  public required Guid KindDocumentRiseQualificationId { get; set; }

  /// <summary>
  /// Модульная программа.
  /// </summary>
  public required bool IsModularProgram { get; set; }

  /// <summary>
  /// Id ВЭД программы.
  /// </summary>
  public Guid? FEAProgramId { get; set; }

  /// <summary>
  /// Id источника финансирования.
  /// </summary>
  public required Guid FinancingTypeId { get; set; }

  /// <summary>
  /// Обязательно наличие ВО (Вот это наследие от прежних разрабов - похоже не нужно).
  /// </summary>
  public required bool IsCollegeProgram { get; set; }

  /// <summary>
  /// Признак программы в архиве.
  /// </summary>
  public required bool IsArchive { get; set; }

  /// <summary>
  /// Сетевая форма.
  /// </summary>
  public required bool IsNetworkProgram { get; set; }

  /// <summary>
  /// Применение ДОТ.
  /// </summary>
  public required bool IsDOTProgram { get; set; }

  /// <summary>
  /// Применение ДОТ полностью.
  /// </summary>
  public required bool IsFullDOTProgram { get; set; }

  /// <summary>
  /// Форма обучения.
  /// </summary>
  [JsonIgnore]
  public virtual EducationForm? EducationForm { get; set; } //= null!;

  /// <summary>
  /// Вид документа повышения квалификации.
  /// </summary>
  [JsonIgnore]
  public virtual KindDocumentRiseQualification? KindDocumentRiseQualification { get; set; } //= null!;

  /// <summary>
  /// ВЭД программы.
  /// </summary>
  [JsonIgnore]
  public virtual FEAProgram? FEAProgram { get; set; }

  /// <summary>
  /// Источник финансирования.
  /// </summary>
  [JsonIgnore]
  public virtual FinancingType? FinancingType { get; set; }//= null!;

  /// <summary>
  /// Группы обучения.
  /// </summary>
  [JsonIgnore]
  public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}