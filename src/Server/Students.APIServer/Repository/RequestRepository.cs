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
  private readonly IOrderRepository _orderRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Добавление приказа в заявку.
  /// </summary>
  /// <param name="requestId">Идентификатор заявки.</param>
  /// <param name="order">Приказ.</param>
  /// <returns>Идентификатор заявки.</returns>
  public async Task<Guid?> AddOrderToRequest(Guid requestId, Order order)
  {
    var request = await this.FindById(requestId);
    if(request is null)
      return null;

    order.RequestId = requestId;
    await this._orderRepository.Create(order);

    return requestId;
  }

  /// <summary>
  /// Список заявок, в которые подавал студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список заявок.</returns>
  public async Task<IEnumerable<Request>?> GetListRequestsOfStudentExists(Guid studentId)
  {
    var student = await this._ctx.FindAsync<Student>(studentId);

    if(student is null)
      return null;

    await this._ctx.Entry(student).Collection(s => s.Requests!).LoadAsync();

    return student.Requests;
  }

  /// <summary>
  /// Пагинация заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  public async Task<PagedPage<RequestsDTO>> GetRequestsDTOByPage(int page, int pageSize)
  {
    var query = this._ctx.Requests.AsNoTracking()
      .Include(s => s.Student)
        .ThenInclude(te => te.TypeEducation)
      .Include(ep => ep.EducationProgram)
      .Include(st => st.Status)
      .Include(o => o.Orders)
        .ThenInclude(ko => ko.KindOrder)
       .Select(x => Mapper.RequestToRequestDTO(x).Result);

    return await PagedPage<RequestsDTO>.ToPagedPage<string>(query, page, pageSize, x => x.StudentFullName);
  }

  /// <summary>
  /// Поиск сущности по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор сущности.</param>
  /// <returns>Сущность.</returns>
  public override async Task<Request?> FindById(Guid id)
  {
    return await this._ctx.Requests.AsNoTracking()
      .Include(x => x.Student)
      .ThenInclude(y => y.TypeEducation)
      .Include(x => x.EducationProgram)
      .Include(x => x.Status)
      .FirstOrDefaultAsync(x => x.Id == id);
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
    this._ctx = context;
    this._orderRepository = orderRepository;
  }

  #endregion
}