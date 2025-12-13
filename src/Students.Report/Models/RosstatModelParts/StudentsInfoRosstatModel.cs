namespace Students.Reports.Models.RosstatModelParts;

public class StudentsInfoRosstatModel
{
  // Не понятно где в модели студента взять присвоена ли квалификация. Это столбец 6.
  # region Общая численность. Стоока 01
  /// <summary>
  /// Студенты обучавшиеся по модульным программам повышения квалификации.
  /// </summary>
  public int AdvancedModuleStudents { get; set; }
  
  /// <summary>
  /// Студенты обучавшиеся по модульным программам переподготовки.
  /// </summary>
  public int RetrainingModuleStudents{ get; set; }
  
  /// <summary>
  /// Всего студентов - женщин.
  /// </summary>
  public int WomanTotal { get; set; }
  # endregion

  #region Работники организаций и предприятий. Строка 02 и 03

  /// <summary>
  /// Работники предприятий и организаций, обучавшиеся по программам повышения квалификации.
  /// </summary>
  public int AdvancedStudentsWorkers { get; set; }

  #endregion
  
  
}