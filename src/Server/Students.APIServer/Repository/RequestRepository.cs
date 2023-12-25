using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private IStudentRepository _studentRepository;
        private ModelStateDictionary _modelState;

        public RequestRepository(StudentContext context,  IStudentRepository studRep) : base(context)
        {
            _ctx = context;
            _studentRepository = studRep;
            _modelState = new ModelStateDictionary();
        }
        protected async Task<bool> ValidateRequest(Request requestToValidate)
        {
             if(_ctx.Requests == null || _ctx.Requests.Count()==0) return _modelState.IsValid;
             if (await FindRequestByPhoneFromRequestAsync(requestToValidate) != null)
                _modelState.AddModelError("Заявка", "Пользователь с этим e-mail адресом уже оставил заявку на этот курс.");
             if (await FindRequestByPhoneFromRequestAsync(requestToValidate) != null)
                _modelState.AddModelError("Заявка", "Пользователь с этим номером телефона уже оставил заявку на этот курс.");
 
            return _modelState.IsValid;
        }

        public async Task<Request?> Create(Request item)
        {
            if (!await ValidateRequest(item)) return null;
            var existStudent = await _studentRepository.FindByPhoneAndEmail(item.Phone, item.Email);
            //Меняем GUID студента когда нашли его в базе по связке телефон и email
            if (existStudent != null) item.StudentId = existStudent.Id;

            return await base.Create(item);
        }
        public async Task<Request?> FindRequestByEmailFromRequestAsync(Request request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
             return await _ctx.Requests.AsNoTracking()
            .FirstOrDefaultAsync(x =>
                       x.Email.ToLower().Equals(request.Email.ToLower()) 
                    && x.EducationProgramId.Equals(request.EducationProgramId));
        }
        public async Task<Request?> FindRequestByPhoneFromRequestAsync(Request request)
        {
                if (request == null) throw new ArgumentNullException(nameof(request));
            return await _ctx.Requests.AsNoTracking()
            .FirstOrDefaultAsync(x => 
                   x.Phone.GetPhoneFromStr().Equals(request.Phone.GetPhoneFromStr())
                && x.EducationProgramId.Equals(request.EducationProgramId));
        }

        public async Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id)
        {
            return await Task.FromResult( _ctx.Requests.AsNoTracking().Where(x => x.StudentId.Equals(id)).ToList().AsEnumerable());
        }

    }
}
