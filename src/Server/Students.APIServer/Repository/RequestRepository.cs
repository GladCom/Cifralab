using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
using Students.APIServer.Extension.Pagination;
using Students.DBCore.Contexts;
using Students.Models;
using System.Numerics;

namespace Students.APIServer.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        private readonly StudentContext _ctx;
        public RequestRepository(StudentContext context) : base(context)
        {
            _ctx = context;
        }

        public async Task<Request> FindRequestByEmailFromRequestAsync(Request request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return await _ctx.Requests.AsNoTracking()
            .FirstOrDefaultAsync(x =>
                       x.EmailPrepeared.Equals(request.EmailPrepeared) 
                    && x.EducationProgramId.Equals(request.EducationProgramId));
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }
        public async Task<Request> FindRequestByPhoneFromRequestAsync(Request request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return await _ctx.Requests.AsNoTracking()
            .FirstOrDefaultAsync(x => 
                   x.PhonePrepeared.Equals(request.PhonePrepeared)
                && x.EducationProgramId.Equals(request.EducationProgramId));
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public async Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id)
        {
            return await Task.FromResult( _ctx.Requests.AsNoTracking().Where(x => x.StudentId.Equals(id)).ToList().AsEnumerable());
        }
    }
}
