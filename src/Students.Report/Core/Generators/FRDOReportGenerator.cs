using ClosedXML.Excel;
using Students.Models.Filters.Filters;
using Students.Reports.Core.Interfaces;
using Students.Reports.Core.Services.Constants;
using Students.Reports.Core.Services.Extensions;
using Students.Reports.Core.Services.Options;
using Students.Reports.Repositories;

namespace Students.Reports.Core.Generators;

/// <summary>
///   Генератор отчета ФРДО.
/// </summary>
public class FRDOReportGenerator : BaseReportGenerator, IFRDOReportGenerator
{
  private readonly FRDOReportRepository _reportRepository;

  /// <summary>
  ///   Генерировать отчет ФРДО.
  /// </summary>
  /// <returns>Книга.</returns>
  public async Task<XLWorkbook?> ReportForExcelAsync(GroupFilter filter)
  {
    var listReportData = await this._reportRepository.Get(filter);
    var workbook = new XLWorkbook(this.PathTemplate("FRDO.xlsx"));
    var worksheet = workbook.Worksheet("Шаблон");
    worksheet.FillArea(new FillAreaOptions
    {
      Entities = listReportData,
      StartRow = FRDOConstants.BeginningOfReportFilling
    });
    return workbook;
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="reportRepository">Репозиторий.</param>
  public FRDOReportGenerator(FRDOReportRepository reportRepository)
  {
    this._reportRepository = reportRepository;
  }
}