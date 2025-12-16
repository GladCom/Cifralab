namespace Students.Reports.Models.RosstatModelParts;

/// <summary>
/// Сведения об образовательных программах, реализуемых организацией (п 1.3 отчета)
/// </summary>
public class EducationProgrammInfoRosstatModel : PartialInfoRosstatModel
{
  /// <summary>
  /// Количество программ.
  /// </summary>
  public int ProgramsCount {get; set;}
  
  /// <summary>
  /// Количество студентов, прошедших программы.
  /// </summary>
  public int StudentsCount {get; set;}
  
  /// <summary>
  /// Количество реализованных сетевых программ повышения квалификации.
  /// </summary>
  public int ProgramsNetworkCount {get; set;}
  
  /// <summary>
  /// Количество реализованных сетевых программ повышения квалификации.
  /// </summary>
  public int ProgramsNetworkStudentsCount {get; set;}
  
  /// с использованием ресурсов иностранных организаций везде считаю 0. Такого нет в модели.
  /// Договоров с организациями тоже нет. Потому тоже везде считаю как 0.
}