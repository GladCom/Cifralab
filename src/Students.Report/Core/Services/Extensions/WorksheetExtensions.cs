using ClosedXML.Excel;
using Students.Reports.Core.Services.Options;

namespace Students.Reports.Core.Services.Extensions;

/// <summary>
///   Расширение IXLWorksheet.
/// </summary>
public static class WorksheetExtensions
{
  /// <summary>
  ///   Заполнение области отчета.
  /// </summary>
  /// <param name="worksheet">Лист.</param>
  /// <param name="options">Опции.</param>
  /// <returns>Лист.</returns>
  public static void FillArea(this IXLWorksheet worksheet, FillAreaOptions options)
  {
    var entityCounter = options.Entities!.Count();
    var currentRow = options.StartRow;
    var currentColumn = options.StartColumn;

    if(options.DownShift)
      worksheet.Row(currentRow).InsertRowsBelow(entityCounter);
    foreach(var row in options.Entities!)
    {
      var columns = row.GetType().GetProperties();
      foreach(var column in columns)
      {
        var value = column.GetValue(row);
        worksheet.Cell(currentRow, currentColumn++).Value = value is int valueInt ?
          valueInt :
          (XLCellValue)(value?.ToString() ?? string.Empty);
      }
      currentColumn = options.StartColumn;
      currentRow++;
    }

    worksheet.Row(currentRow).Delete();
  }

  /// <summary>
  ///   Добавление формул Sum.
  /// </summary>
  /// <param name="worksheet">Лист.</param>
  /// <param name="options">Опции.</param>
  /// <returns>Лист.</returns>
  public static void FillAreaSumFormulas(
    this IXLWorksheet worksheet,
    FillAreaSumFormulasOptions options)
  {
    for(var i = options.StartColumn; i < options.EndColumn; i++)
      worksheet.Cell(options.RowFormula, i).FormulaA1
        = $"=SUM({ExcelMetadata.ExcelColumnName[i]}{options.StartRow}:{ExcelMetadata.ExcelColumnName[i]}{options.RowFormula - 1})";
  }
}