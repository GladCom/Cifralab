namespace Students.Reports.Models.RosstatModelParts;

/// <summary>
/// Сведения об образовательных программах, реализуемых организацией (п 1.3 отчета)
/// </summary>
public class EducationInfoRosstatModel
{
  /// <summary>
  /// Количество программ повышения квалификации.
  /// </summary>
  public int AdvancedTrainingProgramsCount {get; set;}
  
  /// <summary>
  /// Количество программ переподготовки.
  /// </summary>
  public int ProfessionalRetrainingProgramsCount {get; set;}
  
  /// <summary>
  /// Количество студентов, прошедших программу повышения квалификации.
  /// </summary>
  public int AdvancedTrainingProgramStudentsCount {get; set;}
  
  /// <summary>
  /// Количество студентов, прошедших программу переподготовки.
  /// </summary>
  public int ProfessionalRetrainingProgramStudentsCount {get; set;}
  
  /// <summary>
  /// Количество реализованных сетевых программ повышения квалификации.
  /// </summary>
  public int AdvancedTrainingProgramsNetworkCount {get; set;}
  
  /// <summary>
  /// Количество реализованных сетевых программ переподготовки.
  /// </summary>
  public int ProfessionalRetrainingProgramNetworkCount {get; set;}
  
  /// <summary>
  /// Количество реализованных сетевых программ повышения квалификации.
  /// </summary>
  public int AdvancedTrainingProgramsNetworkStudentsCount {get; set;}
  
  /// <summary>
  /// Количество реализованных сетевых программ переподготовки.
  /// </summary>
  public int ProfessionalRetrainingProgramNetworkStudentsCount {get; set;}
  
  /// с использованием ресурсов иностранных организаций везде считаю 0. Такого нет в модели.
  /// Договоров с организациями тоже нет. Потому тоже везде считаю как 0.
}