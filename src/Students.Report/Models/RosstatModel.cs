using Students.Reports.Models.RosstatModelParts;

namespace Students.Reports.Models;

/// <summary>
///   Модель отчета.
/// </summary>
public class RosstatModel
{
  /// <summary>
  ///  Сведения об образовательных программах, реализуемых организацией (п 1.3 отчета)
  /// </summary>
  public EducationInfoRosstatModel EducationInfo { get; set; } = new EducationInfoRosstatModel();
  
  /// <summary>
  /// Распределение слушателей по программам. (п 2.1 отчета)
  /// </summary>
  public StudentsInfoRosstatModel StudentsInfo { get; set; } = new StudentsInfoRosstatModel();
}