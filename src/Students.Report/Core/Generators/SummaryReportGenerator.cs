using ClosedXML.Excel;
using Students.Models.Filters.Filters;
using Students.Reports.Core.Interfaces;
using Students.Reports.Core.Services.Constants;
using Students.Reports.Core.Services.Extensions;
using Students.Reports.Core.Services.Options;
using Students.Reports.Models;
using Students.Reports.Repositories;

namespace Students.Reports.Core.Generators;

/// <summary>
///   Генератор сводного отчета.
/// </summary>
public class SummaryReportGenerator : BaseReportGenerator, ISummaryReportGenerator
{
  private readonly CurrentlyStudyingReportRepository _currentlyStudyingContext;
  private readonly FinishingStudiesReportRepository _finishingStudiesContext;

  /// <summary>
  ///   Генерировать сводный отчет.
  /// </summary>
  /// <returns>Книга.</returns>
  public async Task<XLWorkbook?> ReportForExcelAsync(GroupFilter filter)
  {
    var dateNow = DateOnly.FromDateTime(DateTime.Now);
    var workbook = new XLWorkbook(this.PathTemplate("SummaryReport.xlsx"));
    var worksheet = workbook.Worksheet("Шаблон");

    var currentlyStudyingList = await this._currentlyStudyingContext.Get(filter, g => g.EndDate.CompareTo(dateNow) >= 0);
    var finishingStudiesList = await this._finishingStudiesContext.Get(filter, g => g.EndDate.CompareTo(dateNow) < 0);

    FillWorksheet(worksheet, new FillWorksheetOptions<FinishingStudiesSummaryModel>
    {
      EndColumn = SummaryConstants.EndColumnFillingFormulaOfGraduates,
      ListEntity = finishingStudiesList,
      StartingRow = SummaryConstants.BeginningOfReportFilling
    });
    FillWorksheet(worksheet, new FillWorksheetOptions<CurrentlyStudyingSummaryModel>
    {
      EndColumn = SummaryConstants.EndColumnFillingFormulaOfStudy,
      ListEntity = currentlyStudyingList,
      StartingRow = SummaryConstants.BeginningOfReportFilling +
                    finishingStudiesList.Count +
                    SummaryConstants.IndentationBetweenTables
    });

    worksheet.RecalculateAllFormulas();
    return workbook;
  }

  private static void FillWorksheet<TEntity>(
    IXLWorksheet worksheet,
    FillWorksheetOptions<TEntity> options) where TEntity : class
  {
    var listEntities = options.ListEntity!.ToList();
    if(!listEntities.Any())
    {
      worksheet.Row(options.StartingRow).Delete();
      return;
    }

    worksheet.FillArea(new FillAreaOptions
    {
      Entities = listEntities,
      StartRow = options.StartingRow,
      DownShift = true
    });
    worksheet.FillAreaSumFormulas(new FillAreaSumFormulasOptions
    {
      RowFormula = options.StartingRow + listEntities.Count,
      StartRow = options.StartingRow,
      StartColumn = SummaryConstants.StartColumnFillingFormula,
      EndColumn = options.EndColumn
    });
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="finishingStudiesContext">Закончившие обучение.</param>
  /// <param name="currentlyStudyingContext">Продолжающие обучение.</param>
  public SummaryReportGenerator(
    FinishingStudiesReportRepository finishingStudiesContext,
    CurrentlyStudyingReportRepository currentlyStudyingContext
  )
  {
    this._finishingStudiesContext = finishingStudiesContext;
    this._currentlyStudyingContext = currentlyStudyingContext;
  }
}