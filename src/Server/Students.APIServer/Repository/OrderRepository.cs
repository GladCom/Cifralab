using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
    /// <summary>
    /// Репозиторий приказов.
    /// </summary>
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly StudentContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public OrderRepository(StudentContext context) : base(context)
        {
            _context = context;
        }
    }
}
