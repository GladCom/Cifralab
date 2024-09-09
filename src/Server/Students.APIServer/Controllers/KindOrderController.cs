using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// Виды документов.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class KindOrderController : GenericAPiController<KindOrder>
    {
        private readonly IGenericRepository<KindOrder> _genericRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        /// <param name="logger">Логгер.</param>
        public KindOrderController(IGenericRepository<KindOrder> repository, ILogger<KindOrder> logger) : base(repository, logger)
        {
            _genericRepository = repository;
            _logger = logger;
        }
    }
}
