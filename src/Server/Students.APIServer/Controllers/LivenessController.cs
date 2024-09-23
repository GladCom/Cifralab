using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.Models;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// Контроллер живучести сервиса
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LivenessController : ControllerBase
    {
        private readonly ILogger<LivenessController> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">Логгер</param>
        public LivenessController(ILogger<LivenessController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Тест живучести сервиса - тестирование приложения без зависимостейй
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet(Name = "Liveness Probe")]
        public IActionResult Get()
        {
            return StatusCode
            (
                StatusCodes.Status200OK,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
}
