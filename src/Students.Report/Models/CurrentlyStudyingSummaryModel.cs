namespace Students.Reports.Models;

/// <summary>
///   Модель сводного отчета.
/// </summary>
public class CurrentlyStudyingSummaryModel
{
  /// <summary>
  ///   Название программы.
  /// </summary>
  public string? NameProgram { get; set; }

  /// <summary>
  ///   Количество часов.
  /// </summary>
  public string? HoursCount { get; set; }

  /// <summary>
  ///   Группа.
  /// </summary>
  public string? Group { get; set; }

  /// <summary>
  ///   Начало обучения.
  /// </summary>
  public string? StartDate { get; set; }

  /// <summary>
  ///   Конец обучения.
  /// </summary>
  public string? EndDate { get; set; }

  /// <summary>
  ///   Количество зачисленных.
  /// </summary>
  public int NumbersOfStudents { get; set; }

  /// <summary>
  ///   Количество слушателей.
  /// </summary>
  public int GraduatesEverything { get; set; }

  /// <summary>
  ///   Отсев.
  /// </summary>
  public int Dropout { get; set; }
}