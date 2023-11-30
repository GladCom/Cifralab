using Microsoft.AspNetCore.Mvc.ModelBinding;
using Students.APIServer.Extension;
using Students.APIServer.Repository;
using Students.Models;
using System;

namespace Students.APIServer.Services
{
    public class RequestService : IRequestService, IGenericRepository<Request>
    {
        private IRequestRepository _requestRepository;
        private IStudentRepository _studentRepository;
        private ModelStateDictionary _modelState;
        public RequestService(IRequestRepository requestRepository, IStudentRepository studentRepository)
        {
            _requestRepository = requestRepository;
            _studentRepository = studentRepository;
        }
        protected bool ValidateRequest(Request requestToValidate)
        {
            //var studentByEmail = _studentRepository.FindByEmail(requestToValidate.EmailPrepeared);
            //var studentByPhone = _studentRepository.FindByPhone(requestToValidate.PhonePrepeared);

            if (_requestRepository.FindRequestByPhoneFromRequestAsync(requestToValidate) != null)
                _modelState.AddModelError("Заявка", "Пользователь с этим e-mail адресом уже оставил заявку на этот курс.");
            if (_requestRepository.FindRequestByPhoneFromRequestAsync(requestToValidate) != null)
                _modelState.AddModelError("Заявка", "Пользователь с этим номером телефона уже оставил заявку на этот курс.");
            //if (requestToValidate.StudentId!studentByEmail.Result.Equals(requestToValidate.EmailPrepeared)!studentByPhone.Result.Equals(requestToValidate.PhonePrepeared))
            //    _modelState.AddModelError("Заявка", "Пользователь с этим номером телефона уже оставил заявку на этот курс.");

            return _modelState.IsValid;
        }
        public async Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id)
        {
            return await _requestRepository.FindRequesListByStudentGuidAsync(id);
        }

        public async Task<Request> FindRequestByPhoneFromRequestAsync(Request item)
        {
            return await _requestRepository.FindRequestByPhoneFromRequestAsync(item);
        }

        public async Task<Request> FindRequestByEmailFromRequestAsync(Request item)
        {
            return await _requestRepository.FindRequestByEmailFromRequestAsync(item);
        }

        public async Task<Request> Create(Request item)
        {
            if (!ValidateRequest(item)) return null;
            var studentByEmail = _studentRepository.FindByEmail(item.EmailPrepeared);
            var studentByPhone = _studentRepository.FindByPhone(item.PhonePrepeared);
            //Меняем GUID студента когда нашли его в базе по связке телефон и email
            if (studentByEmail.Result.Equals(studentByPhone.Result)) item.StudentId = studentByPhone.Result.Id;

            return await _requestRepository.Create(item);
        }

        public async Task<Request> FindById(Guid id)
        {
            return await _requestRepository.FindById(id);
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return await _requestRepository.Get();
        }

        public async Task<IEnumerable<Request>> Get(Func<Request, bool> predicate)
        {
            return await _requestRepository.Get(predicate);
        }

        public async Task Remove(Request item)
        {
            if(!ValidateRequest(item)) return;
            await _requestRepository.Remove(item);
        }

        public async Task<Request> Update(Request item)
        {
            if(!ValidateRequest(item)) Task.FromResult<Request>(null);
            return await _requestRepository.Update(item);
        }
    }
}
