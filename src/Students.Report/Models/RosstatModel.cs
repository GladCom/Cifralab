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
  public StudentsInfoRosstatModel<EducationProgrammInfoRosstatModel> EducationProgrammInfo { get; set; }
  
  /// <summary>
  /// Распределение слушателей по программам. (п 2.1 отчета)
  /// </summary>
  public StudentsInfoRosstatModel<PartialProgramStats> StudentsInfo { get; set; }
  
  /// <summary>
  /// Распределение слушателей по типам финансирования. (п. 2.2 отчета)
  /// </summary>
  public StudentsInfoRosstatModel<FundingSources> FundingSourcesInfo { get; set; } 
  
  /// <summary>
  /// Распределение студентов по возрастам.
  /// </summary>
  public StudentsInfoRosstatModel<StudentAges> StudentAgesInfo { get; set; }
}