namespace Students.Reports.Core.Services.Constants;

/// <summary>
///   Константы для сводного отчета.
/// </summary>
public static class SummaryConstants
{
  /// <summary>
  ///   Строка с которой начать заполнять отчет.
  /// </summary>
  public const int BeginningOfReportFilling = 6;

  /// <summary>
  ///   Отступ между таблицами в отчете.
  /// </summary>
  public const int IndentationBetweenTables = 4;

  /// <summary>
  ///   Начальная колонка для заполнения формул.
  /// </summary>
  public const int StartColumnFillingFormula = 6;

  /// <summary>
  ///   Конечная колонка для заполнения формул завершивших обучение.
  /// </summary>
  public const int EndColumnFillingFormulaOfGraduates = 10;

  /// <summary>
  ///   Конечная колонка для заполнения формул продолжающих обучение.
  /// </summary>
  public const int EndColumnFillingFormulaOfStudy = 7;

  /// <summary>
  ///   Сертификат о повышении квалификации.
  /// </summary>
  public const string CertificateOfProfessionalDevelopment = "Удостоверение о повышении квалификации";

  /// <summary>
  ///   Диплом о профессиональной переподготовке.
  /// </summary>
  public const string DiplomaOfProfessionalRetraining = "Диплом о профессиональной переподготовке";

  /// <summary>
  ///   Обучение.
  /// </summary>
  public const string Training = "Обучение";

  /// <summary>
  ///   Отчислен.
  /// </summary>
  public const string Expelled = "Отчислен";

  /// <summary>
  ///   Справка.
  /// </summary>
  public const string Certificate = "Справка";
}