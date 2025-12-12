namespace Students.Reports.Models.RosstatModelParts;

public class EducationInfo
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
}