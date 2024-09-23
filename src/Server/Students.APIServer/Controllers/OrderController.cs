using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;

namespace Students.APIServer.Controllers
{
    /// <summary>
    /// Контроллер приказов
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : GenericAPiController<Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _loger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="orderКepository">Репозиторий приказов</param>
        /// <param name="logger">Логгер.</param>
        public OrderController(IOrderRepository orderКepository, ILogger<Order> logger) : base(orderКepository, logger)
        {
            _orderRepository = orderКepository;
            _loger = logger;
        }
    }
}
