using ClosedXML.Excel;
using ClosedXML.Report;
using Students.Models.Filters.Filters;
using Students.Reports.Core.Interfaces;
using Students.Reports.Repositories;

namespace Students.Reports.Core.Generators;

/// <summary>
///   Генератор отчета для Росстата.
/// </summary>
public class RosstatReportGenerator : BaseReportGenerator, IRosstatReportGenerator
{
  private readonly RosstatReportRepository _reportRepository;

  /// <summary>
  ///   Генерировать отчет для Росстата.
  /// </summary>
  /// <returns>Книга.</returns>
  public async Task<XLWorkbook?> ReportForExcelAsync(GroupFilter filter)
  {
    var listReportData = await this._reportRepository.Get(filter);
    var template = new XLTemplate(this.PathTemplate("Form1-PK.xlsx"));
    template.AddVariable(listReportData.FirstOrDefault());
    template.Generate();

    return template.Workbook as XLWorkbook;
  }

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="reportRepository">Репозиторий.</param>
  public RosstatReportGenerator(RosstatReportRepository reportRepository)
  {
    this._reportRepository = reportRepository;
  }
}