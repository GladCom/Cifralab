using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;
using System.Diagnostics;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// Контроллер отчетов
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportController> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="reportRepository">Репозиторий отчетов</param>
        /// <param name="logger">Логгер</param>
        public ReportController(IReportRepository reportRepository, ILogger<ReportController> logger)
        {
            _logger = logger;
            _reportRepository = reportRepository;
        }

        /// <summary>
        /// Полная выгрузка.
        /// </summary>
        /// <returns>Excel файл со всеми сущностями.</returns>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return File(
                    await _reportRepository.GetAll(),
                    "application/zip",
                    "Reports.zip");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while getting Entity");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }
        }
    }
}
