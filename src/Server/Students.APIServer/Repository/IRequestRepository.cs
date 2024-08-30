using Students.Models;


namespace Students.APIServer.Repository
{

    public interface IRequestRepository : IGenericRepository<Request>
    {
        //Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id);
        //Task<Request> FindRequestByPhoneFromRequestAsync(Request request);
        //Task<Request> FindRequestByEmailFromRequestAsync(Request request);
    }
}
