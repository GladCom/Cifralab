using Microsoft.EntityFrameworkCore;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Enums;
using Students.Models.Filters;
using Students.Models.Searches.Searches;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий заявок.
/// </summary>
public class RequestRepository : GenericRepository<Request>, IRequestRepository
{
    #region Поля и свойства

    private readonly IOrderRepository _orderRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IGenericRepository<PhantomStudent> _phantomStudentRepository;
    private readonly Mapper _mapper;

    #endregion

    #region IRequestRepository

    /// <summary>
    /// Создание новой заявки с тильды.
    /// </summary>
    /// <param name="form">DTO с тильды с данными о потенциальном студенте.</param>
    /// <returns>Новая заявка (попутно создается новый студент, если не был найден).</returns>
    public async Task<RequestWebhook> Create(RequestWebhook form)
    {
        var request = await this._mapper.WebhookToRequest(form);

        var student = await this._studentRepository.GetOne(x =>
          x.FullName == form.Name && x.BirthDate.ToString() == form.Birthday && x.Email == form.Email);

        if (student is null)
        {
            if (await this._studentRepository.GetOne(x =>
                 x.FullName == form.Name || x.BirthDate.ToString() == form.Birthday || x.Email == form.Email) is null)
            {
                var newStudent = (await this._mapper.WebhookToPhantomStudent(form)).ToStudent;
                newStudent = await this._studentRepository.Create(newStudent);
                request.StudentId = newStudent.Id;
            }
            else
            {
                var fantomStudent = await this._mapper.WebhookToPhantomStudent(form);
                fantomStudent = await this._phantomStudentRepository.Create(fantomStudent);
                request.PhantomStudentId = fantomStudent.Id;
            }
        }
        else
        {
            request.StudentId = student.Id;
        }

        await this.Create(request);

        return form;
    }

    /// <summary>
    /// Создание новой заявки с фронта.
    /// </summary>
    /// <param name="form">DTO заявки с данными о потенциальном студенте.</param>
    /// <returns>Новая заявка (попутно создается новый студент, если не был найден).</returns>
    public async Task<Request> Create(NewRequestDTO form)
    {
        var request = await this._mapper.NewRequestDTOToRequest(form);

        var fio = $"{form.family} {form.name} {form.patron}";
        var date = form.birthDate;

        var student = await this._studentRepository.GetOne(x =>
          x.Name == form.name && x.Family == form.family && x.Patron == form.patron && x.BirthDate == date && x.Email == form.email);

        if (student is null)
        {
            if (await this._studentRepository.GetOne(x =>
                  x.FullName == fio || x.BirthDate == date || x.Email == form.email) is null)
            {
                var newStudent = (await Mapper.NewRequestDTOToPhantomStudent(form)).ToStudent;
                newStudent = await this._studentRepository.Create(newStudent);
                request.StudentId = newStudent.Id;
            }
            else
            {
                var fantomStudent = await Mapper.NewRequestDTOToPhantomStudent(form);
                fantomStudent = await this._phantomStudentRepository.Create(fantomStudent);
                request.PhantomStudentId = fantomStudent.Id;
            }
        }
        else
        {
            request.StudentId = student.Id;
        }

        request = await this.Create(request);

        return request;
    }

    // Пизда, а не мокап, студента выбирать нужно из списка блять
    /// <summary>
    /// Обновить заявку и её студента.
    /// </summary>
    /// <param name="requestId">Id заявки.</param>
    /// <param name="form">DTO заявки.</param>
    /// <returns>DTO заявки.</returns>
    public async Task<RequestDTO?> Update(Guid requestId, RequestDTO form)
    {
        var resultOld = await this.FindById(requestId);

        if (resultOld is null)
        {
            return null;
        }

        Student? student;

        //Если студент уже привязан, то меняем его реквизиты, но если он совпадет по трем полям с уже существующим, то пусть идут в топку
        if (form.StudentId is not null && form.StudentId != Guid.Empty)
        {
            student = await this._studentRepository.FindById(form.StudentId.Value);
            if (student is not null)
            {
                var tempNewStudent = await this._studentRepository.GetOne(x => x.Phone == form.phone &&
                                                                               x.Email == form.Email &&
                                                                               x.Family == form.family &&
                                                                               x.Name == form.name! &&
                                                                               x.Patron == form.patron!);

                if (tempNewStudent is not null && student.Id != tempNewStudent.Id)
                {
                    //throw new Exception("Попытка задублировать студентов");
                    student = tempNewStudent;
                }

                student.Family = form.family!;
                student.Name = form.name;
                student.Patron = form.patron;
                student.BirthDate = (DateOnly)form.BirthDate!;
                student.Sex = student.Sex;
                student.Address = form.Address!;
                student.Phone = form.phone ?? string.Empty;
                student.Email = form.Email ?? string.Empty;
                student.Projects = form.projects;
                student.IT_Experience = form.IT_Experience!;
                student.TypeEducationId = form.TypeEducationId;
                //Ебать-кололить, нет этого в мокапе, и не нужно было бы, коли выбор был бы из списка, короче этот метод нужно переделывать
                student.ScopeOfActivityLevelOneId = form.ScopeOfActivityLevelOneId != null && (Guid)form.ScopeOfActivityLevelOneId! != Guid.Empty
                  ? (Guid)form.ScopeOfActivityLevelOneId
                  : Guid.Parse("a5e1e718-4747-47f4-b7c3-08e56bb7ea34");
                student.ScopeOfActivityLevelTwoId = form.ScopeOfActivityLevelTwoId;
                student.Speciality = form.speciality;

                resultOld.StudentId = student.Id;
                await this._studentRepository.Update(student.Id, student);
            }
        }
        else
        {
            student = await this._studentRepository.GetOne(x => x.Phone == form.phone &&
                                                                x.Email == form.Email &&
                                                                x.Family == form.family! &&
                                                                x.Name == form.name! &&
                                                                x.Patron == form.patron!);

            if (student is null)
            {
                student = await Mapper.RequestDTOToStudent(form);

                student = await this._studentRepository.Create(student);
                resultOld.StudentId = student.Id;
            }
        }

        resultOld.StatusRequestId = form.StatusRequestId;
        resultOld.StatusEntrancExams = form.statusEntrancExams;
        resultOld.Email = form.Email ?? string.Empty;
        resultOld.Phone = form.phone ?? string.Empty;
        resultOld.Agreement = form.agreement;
        resultOld.EducationProgramId = form.EducationProgramId;
        resultOld.DateOfCreate = form.DateOfCreate;

        await this.Update(requestId, resultOld);

        return await this.GetRequestDTO(resultOld.Id);
    }

    /// <summary>
    /// Добавление приказа в заявку.
    /// </summary>
    /// <param name="requestId">Идентификатор заявки.</param>
    /// <param name="order">Приказ.</param>
    /// <returns>Идентификатор заявки.</returns>
    public async Task<Guid?> AddOrderToRequest(Guid requestId, Order order)
    {
        var request = await this.FindById(requestId);
        if (request is null)
            return null;

        order.RequestId = requestId;
        await this._orderRepository.Create(order);

        return requestId;
    }


    /// <summary>
    /// Пагинация, фильтрация и сортировка заявок
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="sortingField">Сортировочное поле</param>
    /// <param name="isAsc">Направление сортировки. true - asc, false - desc</param>
    /// <param name="filterString">Строка фильтрации</param>
    /// <returns>Страница с заявками</returns>
    public async Task<PagedPage<RequestDTO>> GetRequestDTOByPageFilteredSorted(int page, int pageSize, string sortingField, bool isAsc, string filterString)
    {
        var filter = FiltersSerializer.FilterToTypedFilter<Request>(filterString);
        if (filter is null)
        {
            throw new ArgumentNullException("Filter is null");
        }

        var baseQuery = this.DbSet.AsNoTracking()
            .Include(r => r.Student)
                .ThenInclude(s => s!.TypeEducation)
            .Include(r => r.PhantomStudent)
                .ThenInclude(s => s!.TypeEducation)
            .Include(r => r.EducationProgram)
            .Include(r => r.Status)
            .Include(r => r.Orders)!
                .ThenInclude(o => o.KindOrder);

        var filteredIds = (await this.Get(filter.GetFilterPredicate(), baseQuery)).Select(x => x.Id).ToList();

        if (!filteredIds.Any())
        {
            return new PagedPage<RequestDTO>(new List<RequestDTO>(), 0, page, pageSize);
        }

        var sortLambda = GetSelector<RequestDTO>(sortingField);
        var query = baseQuery
            .Where(r => filteredIds.Contains(r.Id))
            .Select(r => _mapper.RequestToRequestDTO(r).Result);

        return await PagedPage<RequestDTO>.ToPagedPage<object>(query, page, pageSize, sortLambda.Compile(), isAsc);
    }

    /// <summary>
    /// Поиск сущности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>Сущность.</returns>
    public async Task<RequestDTO?> GetRequestDTO(Guid id)
    {
        var request = await this.GetOne(r => r.Id == id, this.DbSet.AsNoTracking()
          .Include(r => r.Student)
            .ThenInclude(s => s!.TypeEducation)
          .Include(r => r.PhantomStudent)
            .ThenInclude(s => s!.TypeEducation)
          .Include(r => r.EducationProgram)
          .Include(r => r.Status)
          .Include(r => r.Orders)!
            .ThenInclude(o => o.KindOrder));

        return request is null ? null : await this._mapper.RequestToRequestDTO(request);
    }

    public async Task<List<EntranceStatusDTO>> GetEntranceExamStatuses()
    {
        return Enum.GetValues(typeof(StatusEntrancExams))
                .Cast<StatusEntrancExams>()
                .Select(status => new EntranceStatusDTO
                {
                    Id = (int)status,
                    Status = status switch
                    {
                        StatusEntrancExams.NotPassed => "Не сдано",
                        StatusEntrancExams.TestTask => "Тестовое задание",
                        StatusEntrancExams.Interview => "Собеседование",
                        StatusEntrancExams.Done => "Выполнено",
                        _ => status.ToString()
                    }
                }).ToList();
    }

  public async Task<IEnumerable<RequestDTO>> SearchRequestsDTO(Search<Request> search)
  {
    // Предикат из твоего RequestSearch
    var predicate = search.GetSearchPredicate();

    // Та же самая "обвязка" Include, что и в GetRequestsDTOByPage
    var baseQuery = this.DbSet.AsNoTracking()
      .Include(r => r.Student)
        .ThenInclude(s => s!.TypeEducation)
      .Include(r => r.PhantomStudent)
        .ThenInclude(s => s!.TypeEducation)
      .Include(r => r.EducationProgram)
      .Include(r => r.Status)
      .Include(r => r.Orders)!
        .ThenInclude(o => o.KindOrder)
      .AsEnumerable()            // дальше фильтруем в памяти через Predicate<Request>
      .Where(r => predicate(r));

    var result = new List<RequestDTO>();

    foreach (var r in baseQuery)
    {
      // у тебя уже есть маппер Request → RequestDTO
      var dto = await this._mapper.RequestToRequestDTO(r);
      result.Add(dto);
    }

    return result;
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
        if (request.DateOfCreate == DateTime.MinValue)
        {
            request.DateOfCreate = DateTime.Now;
        }
        return await base.Create(request);
    }

    /// <summary>
    /// Изменение сущности.
    /// </summary>
    /// <param name="requestId">Идентификатор сущности.</param>
    /// <param name="request">Обновлённая сущность.</param>
    /// <returns>Сущность.</returns>
    public override async Task<Request?> Update(Guid requestId, Request request)
    {
        if (request.StudentId is null || request.PhantomStudentId is null)
            return await base.Update(requestId, request);

        var phantomStudent = await this._phantomStudentRepository.FindById(request.PhantomStudentId.Value);
        if (phantomStudent is not null)
            await this._phantomStudentRepository.Remove(phantomStudent);
        request.PhantomStudentId = null;

        return await base.Update(requestId, request);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    /// <param name="phantomStudentRepository">Репозиторий неподтверждённых студентов.</param>
    /// <param name="studentRepository">Репозиторий студентов.</param>
    /// <param name="orderRepository">Репозиторий приказов.</param>
    /// <param name="mapper">Маппер.</param>
    public RequestRepository(StudentContext context, IOrderRepository orderRepository,
    IStudentRepository studentRepository,
    IGenericRepository<PhantomStudent> phantomStudentRepository, Mapper mapper) : base(context)
    {
        this._orderRepository = orderRepository;
        this._studentRepository = studentRepository;
        this._phantomStudentRepository = phantomStudentRepository;
        this._mapper = mapper;
    }

    #endregion

    #region Приватные методы
    private Expression<Func<T, object>> GetSelector<T>(string propertyName)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.PropertyOrField(param, propertyName);
        var converted = Expression.Convert(body, typeof(object));
        return Expression.Lambda<Func<T, object>>(converted, param);

    }
    #endregion
}