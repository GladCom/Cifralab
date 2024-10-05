using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Report.Interfaces;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// Контроллер отчетов
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        //private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportController> _logger;
        private readonly IReport<XLWorkbook> _report;

        /// <summary>
        /// Получить отчет для Росстата.
        /// </summary>
        /// <returns>Отчет.</returns>
        [HttpPost("GetRostatReport")]
        public async Task<FileResult> GetRosstatReport()
        {
            return CreateFileReport(await _report.GenerateRosstatReport(), "Росстат");
        }

        /// <summary>
        /// Получить отчет ПФДО.
        /// </summary>
        /// <returns>Отчет.</returns>
        [HttpPost("GetPFDOReport")]
        public async Task<FileResult> GetPFDOReport()
        {
            return CreateFileReport(await _report.GeneratePFDOReport(), "ПФДО");
        }

        /// <summary>
        /// Создание файла.
        /// </summary>
        /// <param name="workbook">Книга.</param>
        /// <param name="titleReport">Название отчета.</param>
        /// <returns>Файл.</returns>
        private FileContentResult CreateFileReport(XLWorkbook workbook, string titleReport)
        {
            FileContentResult result;
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                result = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Отчет {titleReport} {DateTime.Now}.xlsx");
                stream.Close();
            }
            return result;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="report">Отчет.</param>
        /// <param name="logger">Логгер</param>
        public ReportController(IReport<XLWorkbook> report, ILogger<ReportController> logger)
        {
            _report = report;
            _logger = logger;
            //_reportRepository = reportRepository;
        }

        ///// <summary>
        ///// Полная выгрузка.
        ///// </summary>
        ///// <returns>Excel файл со всеми сущностями.</returns>
        //[HttpGet()]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        return File(
        //            await _reportRepository.GetAll(),
        //            "application/zip",
        //            "Reports.zip");
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "Error while getting Entity");
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            new DefaultResponse
        //            {
        //                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        //            });
        //    }
        //}
    }
}
