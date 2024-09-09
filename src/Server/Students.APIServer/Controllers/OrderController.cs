using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// Список приказов.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : GenericAPiController<Order>
    {
        private readonly IGenericRepository<Order> _genericRepository;
        private readonly ILogger _loger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        /// <param name="logger">Логгер.</param>
        public OrderController(IGenericRepository<Order> repository, ILogger<Order> logger) : base(repository, logger)
        {
            _genericRepository = repository;
            _loger = logger;
        }
    }
}
