using Students.APIServer.Extension.Pagination;
using Students.Models;


namespace Students.APIServer.Repository
{

    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id);
        Task<Request> FindRequestByPhoneFromRequestAsync(Request request);
        Task<Request> FindRequestByEmailFromRequestAsync(Request request);
        Task<Guid> AddOrderToRequest(Guid id, Order order);
        Task<PagedPage<Request>> GetRequestsByPage(int page, int pageSize);
    }
}
