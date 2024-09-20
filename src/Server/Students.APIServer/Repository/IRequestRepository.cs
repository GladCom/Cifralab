using Students.APIServer.Extension.Pagination;
using Students.Models;


namespace Students.APIServer.Repository
{
    /// <summary>
    /// Интерфейс репозитория заявки
    /// </summary>
    public interface IRequestRepository : IGenericRepository<Request>
    {
        /// <summary>
        /// Поиск заявок по идентификатору студента
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <returns>Список заявок</returns>
        Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id);
        /// <summary>
        /// Поиск заявок по номеру телефона из заявки
        /// </summary>
        /// <param name="request">Заявка</param>
        /// <returns>Заявка</returns>
        Task<Request> FindRequestByPhoneFromRequestAsync(Request request);
        /// <summary>
        /// Поиск заявок по mail из заявки
        /// </summary>
        /// <param name="request">электронная почта</param>
        /// <returns>Заявка</returns>
        Task<Request> FindRequestByEmailFromRequestAsync(Request request);
        /// <summary>
        /// Добавление приказа в заявку
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Guid> AddOrderToRequest(Guid id, Order order);
        /// <summary>
        /// Пагинация заявок
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        Task<PagedPage<Request>> GetRequestsByPage(int page, int pageSize);
    }
}
