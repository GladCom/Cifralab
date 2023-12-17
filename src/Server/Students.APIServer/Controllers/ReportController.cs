using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// ReportController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportController> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        public ReportController(ILogger<ReportController> logger, IReportRepository reportRepository)
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
                    await _reportRepository.GetAllCSV(),
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
