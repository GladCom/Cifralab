using Students.Models;

namespace Students.APIServer.Services
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id);
        Task<Request> FindRequestByPhoneFromRequestAsync(Request item);
        Task<Request> FindRequestByEmailFromRequestAsync(Request item);
        Task<Request> Create(Request item);
        Task<Request> FindById(Guid id);
        Task<IEnumerable<Request>> Get();
        Task<IEnumerable<Request>> Get(Func<Request, bool> predicate);
        Task Remove(Request item);
        Task<Request> Update(Request item);
    }
}
