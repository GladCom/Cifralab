namespace Students.Reports.Core.Services.Options;

/// <summary>
///   Параметры для заполнения формул Sum.
/// </summary>
public class FillAreaSumFormulasOptions
{
  /// <summary>
  ///   Строка формул.
  /// </summary>
  public int RowFormula { get; set; }

  /// <summary>
  ///   Начало отсчета.
  /// </summary>
  public int StartRow { get; set; }

  /// <summary>
  ///   Начальная колонка.
  /// </summary>
  public int StartColumn { get; set; }

  /// <summary>
  ///   Конечная колонка.
  /// </summary>
  public int EndColumn { get; set; }
}