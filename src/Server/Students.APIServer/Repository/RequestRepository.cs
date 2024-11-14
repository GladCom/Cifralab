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

  private readonly IOrderRepository _orderRepository;

  #endregion

  #region IRequestRepository

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
  /// Пагинация заявок.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  public async Task<PagedPage<RequestsDTO>> GetRequestsDTOByPage(int page, int pageSize)
  {
    var query = this.DbSet.AsNoTracking()
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
  public async Task<Request?> GetRequestForDTO(Guid id)
  {
    return await this.GetOne(x => x.Id == id
      , this.DbSet.AsNoTracking()
      .Include(x => x.Student)
      .ThenInclude(y => y.TypeEducation)
      .Include(x => x.EducationProgram)
      .Include(x => x.Status));
  }

  #endregion

  #region Базовый класс

  /// <summary>
  /// Модифицированное создание заявки.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <returns>Заявка.</returns>
  public override async Task<Request> Create(Request request)
  {
    if(request.StudentId is null)
      return await base.Create(request);

    var existingStudentRequests =
      await this.Get(r => r.StudentId == request.StudentId);
    request.IsAlreadyStudied = existingStudentRequests.Any();

    return await base.Create(request);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="orderRepository">Репозиторий приказов.</param>
  public RequestRepository(StudentContext context, IOrderRepository orderRepository) :
    base(context)
  {
    this._orderRepository = orderRepository;
  }

  #endregion
}