using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Students.Models;

namespace Students.APIServer.Controllers
{
    
    /// <summary>
    /// LivenessController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LivenessController : ControllerBase
    {
        private readonly ILogger<LivenessController> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        public LivenessController(ILogger<LivenessController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Liveness Probe - testing the application without dependencies
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
                    Status = Status.Ok,
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
}
