namespace Students.Reports.Models;

/// <summary>
///   Модель отчета.
/// </summary>
public class RosstatModel
{
  /// <summary>
  /// Количество программ повышения квалификации.
  /// </summary>
  public int AdvancedTrainingProgramsCount {get; set;}
  
  /// <summary>
  /// Количество программ переподготовки.
  /// </summary>
  public int ProfessionalRetrainingProgramsCount {get; set;}
}