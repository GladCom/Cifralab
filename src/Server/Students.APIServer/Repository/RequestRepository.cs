using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий заявок.
/// </summary>
public class RequestRepository : GenericRepository<Request>, IRequestRepository
{
  #region Поля и свойства

  private readonly StudentContext _ctx;
  private IStudentRepository _studentRepository;
  private ModelStateDictionary _modelState;
  private IOrderRepository _orderRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Валидация заявки.
  /// </summary>
  /// <param name="requestToValidate">Заявка.</param>
  protected async Task<bool> ValidateRequest(Request requestToValidate)
  {
    if(!_ctx.Requests.Any())
      return _modelState.IsValid;
    if(await FindRequestByEmailFromRequestAsync(requestToValidate) is not null)
      _modelState.AddModelError("Заявка", "Пользователь с этим e-mail адресом уже оставил заявку на этот курс.");
    if(await FindRequestByPhoneFromRequestAsync(requestToValidate) is not null)
      _modelState.AddModelError("Заявка", "Пользователь с этим номером телефона уже оставил заявку на этот курс.");

    return _modelState.IsValid;
  }

  /// <summary>
  /// Создание заявки.
  /// </summary>
  /// <param name="item">Заявка.</param>
  /// <returns>Заявка</returns>
  public override async Task<Request> Create(Request item)
  {
    //Убираем валидацию на наличие подобной. Создаваться будет всегда, пометкой и удалением займется пользователь
    //if (!await ValidateRequest(item)) return null;
    var existStudent = await _studentRepository.FindByPhoneAndEmail(item.Phone, item.Email);
    //Меняем GUID студента когда нашли его в базе по связке телефон и email
    if(existStudent != null)
      item.StudentId = existStudent.Id;

    return await base.Create(item);
  }

  /// <summary>
  /// Поиск похожих заявок по email.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <returns>Заявка</returns>
  /// <exception cref="ArgumentNullException">Входящих параметр не должен быть пустым.</exception>
  public async Task<Request?> FindRequestByEmailFromRequestAsync(Request request)
  {
    if(request == null)
      throw new ArgumentNullException(nameof(request));
    return await Task.FromResult(_ctx.Requests.AsNoTracking()
      .FirstOrDefaultAsync(x =>
        //x.Email.ToLower().Equals(request.Email.ToLower())
        x.Email.ToLower().Equals(request.Email.ToLower()) &&
        x.EducationProgramId.Equals(request.EducationProgramId))).Result;
  }


  /// <summary>
  /// Поиск похожих заявок по номеру телефона.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <returns>Заявка.</returns>
  /// <exception cref="ArgumentNullException">Входящих параметр не должен быть пустым.</exception>
  public async Task<Request?> FindRequestByPhoneFromRequestAsync(Request request)
  {
    if(request == null)
      throw new ArgumentNullException(nameof(request));
    var requests = _ctx.Requests.AsNoTracking().AsAsyncEnumerable();
    await foreach(var item in requests)
    {
      if(item.Phone.ToLower().Equals(request.Phone.ToLower()) &&
          item.EducationProgramId.Equals(request.EducationProgramId))
      {
        return item;
      }
    }

    return null;
  }


  /// <summary>
  /// Поиск заявок по идентификатору студента.
  /// </summary>
  /// <param name="id">Идентификатор студента.</param>
  /// <returns>Список заявок.</returns>
  public async Task<IEnumerable<Request>> FindRequestListByStudentGuidAsync(Guid id)
  {
    return await Task.FromResult(
      _ctx.Requests.AsNoTracking().Where(x => x.StudentId.Equals(id)).ToList().AsEnumerable());
  }

  /// <summary>
  /// Добавление приказа в заявку.
  /// </summary>
  /// <param name="id">Идентификатор заявки.</param>
  /// <param name="order">Приказ.</param>
  /// <returns>Идентификатор заявки.</returns>
  /// <exception cref="ArgumentNullException">Не найдена заявки с указанным идентификатором.</exception>
  public async Task<Guid> AddOrderToRequest(Guid id, Order order)
  {
    var findRequest = await FindById(id);
    //var findRequest = await _ctx.Set<Request>().FindAsync(id);
    if(findRequest == null)
      throw new ArgumentNullException(nameof(findRequest));

    order.RequestId = id;
    var actualOrder = await _orderRepository.Create(order);

    return id;
  }

  /// <summary>
  /// Пагинация списка заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  public async Task<PagedPage<Request>> GetRequestsByPage(int page, int pageSize)
  {
    var items = await PagedPage<Request>.ToPagedPage<string>(_ctx.Requests, page, pageSize,
      (x) => x.Student != null ? x.Student!.FullName : "");

    return items;
  }

  /// <summary>
  /// Пагинация заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  public async Task<PagedPage<RequestsDTO>> GetRequestsDTOByPage(int page, int pageSize)
  {
    var query = from r in _ctx.Requests
                join s in _ctx.Students on r.StudentId equals s.Id into s_jointable
                from s1 in s_jointable.DefaultIfEmpty()
                join e in _ctx.EducationPrograms on r.EducationProgramId equals e.Id into e_jointable
                from e1 in e_jointable.DefaultIfEmpty()
                join te in _ctx.TypeEducation on s1.TypeEducationId equals te.Id into te_jointable
                from te1 in te_jointable.DefaultIfEmpty()
                join sr in _ctx.StatusRequests on r.StatusRequestId equals sr.Id into sr_jointable
                from sr1 in sr_jointable.DefaultIfEmpty()
                select new RequestsDTO()
                {
                  Id = r.Id,
                  StudentId = r.Id,
                  StudentFullName = s1 != null ? s1.FullName : "",
                  BirthDate = s1 != null ? s1.BirthDate : null,
                  Address = s1 != null ? s1!.Address : null,
                  TypeEducation = te1 != null ? te1!.Name : null,
                  TypeEducationId = te1 != null ? te1!.Id : null,
                  Email = s1 != null ? s1!.Email : null,
                  EducationProgramId = r.EducationProgramId,
                  EducationProgram = e1 != null ? e1.Name : null,
                  StatusRequestId = r.StatusRequestId,
                  StatusRequest = sr1 != null ? sr1.Name : null
                };

    return await PagedPage<RequestsDTO>.ToPagedPage<string>(query, page, pageSize, (x) => x.StudentFullName);
  }
  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="studRep">Репозиторий студентов.</param>
  /// <param name="orderRepository">Репозиторий приказов.</param>
  public RequestRepository(StudentContext context, IStudentRepository studRep, IOrderRepository orderRepository) :
    base(context)
  {
    _ctx = context;
    _studentRepository = studRep;
    _modelState = new ModelStateDictionary();
    _orderRepository = orderRepository;
  }

  #endregion
}