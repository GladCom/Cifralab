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
        private readonly ILogger<ReportController> _logger;
        private readonly IReport<XLWorkbook> _report;

        /// <summary>
        /// Получить отчет для Росстата.
        /// </summary>
        /// <returns>Отчет.</returns>
        [HttpPost("GetRostatReport")]
        public async Task<FileResult> GetRosstatReport()
        {
            var workbook = await _report.GenerateRosstatReport() ?? throw new ArgumentNullException("Нет данных."); 
            return CreateFileReport(workbook, "Росстат");
        }

        /// <summary>
        /// Получить отчет ФРДО.
        /// </summary>
        /// <returns>Отчет.</returns>
        [HttpPost("GetPFDOReport")]
        public async Task<FileResult> GetPFDOReport()
        {
            var workbook = await _report.GenerateFRDOReport() 
                ?? throw new ArgumentNullException("Нет данных.");
            return CreateFileReport(workbook, "ФРДО");
        }

        /// <summary>
        /// Создание файла.
        /// </summary>
        /// <param name="workbook">Книга.</param>
        /// <param name="nameReport">Название отчета.</param>
        /// <returns>Файл.</returns>
        private FileContentResult CreateFileReport(XLWorkbook workbook, string nameReport)
        {
            FileContentResult result;
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                result = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Отчет {nameReport} {DateTime.Now}.xlsx");
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
        }
    }
}
