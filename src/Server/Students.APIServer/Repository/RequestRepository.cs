using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension.Pagination;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
    /// <summary>
    /// Репозиторий заявок
    /// </summary>
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        private readonly StudentContext _ctx;
        private IStudentRepository _studentRepository;
        private ModelStateDictionary _modelState;
        private IOrderRepository _orderRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        /// <param name="studRep">Репозиторий студентов</param>
        /// <param name="orderRepository">Репозиторий приказов</param>
        public RequestRepository(StudentContext context,  IStudentRepository studRep, IOrderRepository orderRepository) : base(context)
        {
            _ctx = context;
            _studentRepository = studRep;
            _modelState = new ModelStateDictionary();
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Валидация заявки
        /// </summary>
        /// <param name="requestToValidate">Заявка</param>
        /// <returns></returns>
        protected async Task<bool> ValidateRequest(Request requestToValidate)
        {
             if(_ctx.Requests == null || _ctx.Requests.Count()==0) return _modelState.IsValid;
             if (await FindRequestByEmailFromRequestAsync(requestToValidate) != null)
                _modelState.AddModelError("Заявка", "Пользователь с этим e-mail адресом уже оставил заявку на этот курс.");
             if (await FindRequestByPhoneFromRequestAsync(requestToValidate) != null)
                _modelState.AddModelError("Заявка", "Пользователь с этим номером телефона уже оставил заявку на этот курс.");
 
            return _modelState.IsValid;
        }

        /// <summary>
        /// Создание заявки
        /// </summary>
        /// <param name="item">Заявка</param>
        /// <returns>Заявка</returns>
        public async Task<Request?> Create(Request item)
        {
            if (!await ValidateRequest(item)) return null;
            var existStudent = await _studentRepository.FindByPhoneAndEmail(item.Phone, item.Email);
            //Меняем GUID студента когда нашли его в базе по связке телефон и email
            if (existStudent != null) item.StudentId = existStudent.Id;

            return await base.Create(item);
        }

        /// <summary>
        /// Поиск похожих заявок по email
        /// </summary>
        /// <param name="request">заявка</param>
        /// <returns>Заявка</returns>
        /// <exception cref="ArgumentNullException">Входящих аараметр не должен дыть пустым</exception>
        public async Task<Request?> FindRequestByEmailFromRequestAsync(Request request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            return await Task.FromResult(_ctx.Requests.AsNoTracking()
                .FirstOrDefaultAsync(x =>
                //x.Email.ToLower().Equals(request.Email.ToLower())
                x.Email.ToLower().Equals(request.Email.ToLower()) &&
                x.EducationProgramId.Equals(request.EducationProgramId))).Result;
        }


        /// <summary>
        /// Поиск похожих заявок по номеру телефона
        /// </summary>
        /// <param name="request">заявка</param>
        /// <returns>заявка</returns>
        /// <exception cref="ArgumentNullException">Входящих параметр не должен дыть пустым</exception>
        public async Task<Request?> FindRequestByPhoneFromRequestAsync(Request request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
			var Requests = _ctx.Requests.AsNoTracking().AsAsyncEnumerable();
            await foreach (var item in Requests)
            {
                if (item.Phone.ToLower().Equals(request.Phone.ToLower()) &&
                    item.EducationProgramId.Equals(request.EducationProgramId))
                {
                    return item;
                }
            }
			return null;
        }


        /// <summary>
        /// Поиск заявок по идентификатору студента
        /// </summary>
        /// <param name="id">идентификатор студента</param>
        /// <returns>Список заявок</returns>
        public async Task<IEnumerable<Request>> FindRequesListByStudentGuidAsync(Guid id)
        {
            return await Task.FromResult( _ctx.Requests.AsNoTracking().Where(x => x.StudentId.Equals(id)).ToList().AsEnumerable());
        }

        /// <summary>
        /// Добавление приказа в заявку.
        /// </summary>
        /// <param name="id">Идентификатор заявки.</param>
        /// <param name="order">Приказ.</param>
        /// <returns>Идентификатор заявки</returns>
        /// <exception cref="ArgumentNullException">Не найдена заявки с указанным идентификатором</exception>
        public async Task<Guid> AddOrderToRequest(Guid id, Order order)
        {
            var findRequest = await FindById(id);
            //var findRequest = await _ctx.Set<Request>().FindAsync(id);
            if(findRequest == null) throw new ArgumentNullException(nameof(findRequest));
            
            order.RequestId = id;
            var actualOrder = await _orderRepository.Create(order);

            return id;
        }

        /// <summary>
        /// Пагинация списка заявок
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public async Task<PagedPage<Request>> GetRequestsByPage(int page, int pageSize)
        {
            return await PagedPage<Request>.ToPagedPage(_ctx.Requests, page, pageSize);
        }
    }
}
