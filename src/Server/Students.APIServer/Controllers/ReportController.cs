using System.Diagnostics;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Students.Models.Filters.Filters;
using Students.Models.WebModels;
using Students.Reports.Core.Interfaces;

namespace Students.APIServer.Controllers;

/// <summary>
///   Контроллер отчетов.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
  #region Поля и свойства

  private readonly ILogger<ReportController> _logger;
  private readonly IFRDOReportGenerator _frdoReportGenerator;
  private readonly IRosstatReportGenerator _rosstatReportGenerator;
  private readonly ISummaryReportGenerator _summaryReportGenerator;

  #endregion

  #region Методы

  /// <summary>
  ///   Получить отчет для Росстата.
  /// </summary>
  /// <returns>Отчет.</returns>
  [HttpPost("GetRostatReport")]
  public async Task<IActionResult> GetRosstatReport([FromBody] GroupFilter filter)
  {
    try
    {
      var workbook = await this._rosstatReportGenerator.ReportForExcelAsync(filter);
      return workbook is null
       ? this.NotFound("Нет данных.")
       : this.CreateFileReport(workbook, "Росстат");
    }
    catch(Exception e)
    {
      return this.Exception(e);
    }
  }

  /// <summary>
  ///   Получить отчет ФРДО.
  /// </summary>
  /// <returns>Отчет.</returns>
  [HttpPost("GetPFDOReport")]
  public async Task<IActionResult> GetPFDOReport([FromBody] GroupFilter filter)
  {
    try
    {
      var workbook = await this._frdoReportGenerator.ReportForExcelAsync(filter);
      return workbook is null
        ? this.NotFound("Нет данных.")
        : this.CreateFileReport(workbook, "ФРДО");
    }
    catch(Exception e)
    {
      return this.Exception(e);
    }
  }

  /// <summary>
  ///   Получить сводный отчет.
  /// </summary>
  /// <returns>Отчет.</returns>
  [HttpPost("GetSummaryReport")]
  public async Task<IActionResult> GetSummaryReport([FromBody] GroupFilter filter)
  {
    try
    {
      var workbook = await this._summaryReportGenerator.ReportForExcelAsync(filter);
      return workbook is null
       ? this.NotFound("Нет данных.")
       : this.CreateFileReport(workbook, "по обучающимся");
    }
    catch(Exception e)
    {
      return this.Exception(e);
    }
  }

  /// <summary>
  ///   Создание файла.
  /// </summary>
  /// <param name="workbook">Книга.</param>
  /// <param name="nameReport">Название отчета.</param>
  /// <returns>Файл.</returns>
  private FileContentResult CreateFileReport(XLWorkbook workbook, string nameReport)
  {
    using var stream = new MemoryStream();
    workbook.SaveAs(stream);
    var result = this.File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
      $"Отчет {nameReport} {DateTime.Now}.xlsx");
    return result;
  }

  private IActionResult Exception(Exception e)
  {
    this._logger.LogError(e, "Error generating the report.");
    return this.StatusCode(StatusCodes.Status500InternalServerError, new DefaultResponse
    {
      RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
    });
  }

  #endregion

  #region Конструкторы

  /// <summary>
  ///   Конструктор.
  /// </summary>
  /// <param name="fRDOReportGenerator">Генератор очета ФРДО.</param>
  /// <param name="summaryReportGenerator">Гереатор сводного отчета.</param>
  /// <param name="rosstatReportGenerator">Генератор отчета для Росстата.</param>
  /// <param name="logger">Логгер.</param>
  public ReportController(
    IFRDOReportGenerator fRDOReportGenerator,
    ISummaryReportGenerator summaryReportGenerator,
    IRosstatReportGenerator rosstatReportGenerator,
    ILogger<ReportController> logger)
  {
    this._frdoReportGenerator = fRDOReportGenerator;
    this._summaryReportGenerator = summaryReportGenerator;
    this._rosstatReportGenerator = rosstatReportGenerator;
    this._logger = logger;
  }

  #endregion
}