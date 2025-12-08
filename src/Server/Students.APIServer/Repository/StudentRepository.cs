using Microsoft.EntityFrameworkCore;
using Npgsql;
using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий студентов.
/// </summary>
public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
  #region Поля и свойства

  private readonly IStudentHistoryRepository _studentHistoryRepository;
  private readonly IGroupRepository _groupRepository;

  #endregion

  #region IStudentRepository

  /// <summary>
  /// Список студентов с пагинацией.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Список студентов с пагинацией.</returns>
  public async Task<PagedPage<StudentDTO>> GetStudentsByPage(int page, int pageSize)
  {
    var query = this.DbSet
      .Include(s => s.GroupStudent!)
        .ThenInclude(gs => gs.Request!)
          .ThenInclude(r => r.Status)
      .Include(s => s.GroupStudent)!
        .ThenInclude(gs => gs.Group)
          .ThenInclude(g => g!.EducationProgram)
      .Include(te => te.TypeEducation!).Select(x => Mapper.StudentToStudentDTO(x).Result);

    return await PagedPage<StudentDTO>.ToPagedPage<string>(query, page, pageSize, x => x.StudentFamily);
  }

  /// <summary>
  /// Поиск студента (с подгрузкой данных о группах и заявках) по идентификатору.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Студент.</returns>
  public async Task<Student?> GetStudentWithGroupsAndRequests(Guid studentId)
  {
    return await this.GetOne(x => x.Id == studentId, this.DbSet
      .Include(x => x.Groups)
      .Include(x => x.Requests)
      .AsNoTracking());
  }

  /// <summary>
  /// Студент проходил обучение в этом году.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="requestId">Идентификатор заявки, для которой производиться проверка.</param>
  public async Task<bool> IsAlreadyStudied(Guid studentId, Guid requestId)
  {
    return await this.GetOne(s => s.Id == studentId && s.Requests!.Any(y => y.Id != requestId &&
                                           y.Orders!.Any(e => e.KindOrder!.Name!.ToLower() == "о зачислении" &&
                                                              e.Date.Year == DateTime.Now.Year)),
      this.DbSet
        .Include(s => s.Requests)!
          .ThenInclude(r => r.Orders)!
          .ThenInclude(o => o.KindOrder)) is not null;
  }

  #endregion

  #region Базовый класс

  /// <summary>
  /// Изменить студента.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="student">Обновлённый студент.</param>
  /// <returns>Студент.</returns>
  public override async Task<Student?> Update(Guid studentId, Student student)
  {
    var oldStudent = await this.FindById(studentId);
    StudentHistory? studentHistory = null;
    if(oldStudent is not null)
    {
      studentHistory = await this._studentHistoryRepository.CreateStudentHistory(oldStudent, student);
    }

    try
    {
      return await base.Update(studentId, student);
    }
    catch(Exception e)
    {
      if(studentHistory is not null)
        await this._studentHistoryRepository.Remove(studentHistory);

      throw new Exception(string.Empty, e);
    }
  }
  
  /// <summary>
  /// Зачисление студента в группу.
  /// </summary>
  /// <param name="studentId">ID студента.</param>
  /// <param name="requestId">ID заявки студента.</param>
  /// <param name="groupId">ID группы в которую надо зачислить студента.</param>
  /// <returns>Студент с обновленными группами.</returns>
  /// <exception cref="ArgumentException">Возникает в случае если не сущетсвует группа студент или заявка.</exception>
  /// <exception cref="InvalidOperationException">Возникает при попытке добавить студента в группу, где он уже есть
  /// или в случае, если студент не подавал туда заявку или заявка уже использована.</exception>
  public async Task<Student?> EnrollStudentInGroup(Guid requestId, Guid groupId)
  {
    var request = await this.GetValidEnrollmentRequestWithStudent(requestId, groupId);

    try
    {
      var newGroupStudent = new GroupStudent()
      {
        StudentId = request.Student.Id,
        GroupId = groupId,
        RequestId = requestId
      };
      if (request.Student.GroupStudent == null)
        request.Student.GroupStudent = new List<GroupStudent>();
      await this._context.AddAsync(newGroupStudent);
      await this._context.SaveChangesAsync();
      return request.Student;
    }
    
    // Так как добавляем GroupStudent в которой первичный ключ requestId ошибка говорит о том,
    // что по этой заявке студент уже зачислен в группу
    catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
    {
      throw new InvalidOperationException("Based on this request, the student has already been enrolled in the group.", ex);
    }
  }

  /// <summary>
  /// Получить проверенную заявку для зачисления со студентом.
  /// </summary>
  /// <param name="requestId">Id заявки студента.</param>
  /// <param name="groupId">ID группы в которую надо зачислить студента.</param>
  /// <exception cref="ArgumentException">Возвращается если группа или заявка не найдены.</exception>
  /// <exception cref="InvalidOperationException">Возвращается если действие зачисления недопустимо.</exception>
  /// <returns>Заявка со студентом.</returns>
  private async Task<Request> GetValidEnrollmentRequestWithStudent(Guid requestId, Guid groupId)
  {
    var group = await this._context.Groups.FindAsync(groupId);
    if (group == null)
    {
      throw new ArgumentException("Group not found");
    }
    
    var request = await this._context.Requests
      .Include(r => r.Student)
        .ThenInclude(s=>s.GroupStudent)
      .Include(r=> r.EducationProgram)
      .SingleOrDefaultAsync(r => r.Id == requestId);

    if (request == null)
    {
      throw new ArgumentException("Request not found");
    }
    
    if (group.EducationProgramId != request?.EducationProgramId)
    {
      throw new InvalidOperationException("The education program group does not match the requested program");
    }

    if (request.Student == null)
    {
      throw new InvalidOperationException("The student is not assigned to this request");
    }

    if (request.Student.GroupStudent?.Any(g => g.GroupId == groupId) == true)
    {
      throw new InvalidOperationException("The student has already been enrolled in the group");
    }
    
    return request;
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="studentHistoryRepository">Репозиторий групп студентов.</param>
  public StudentRepository(StudentContext context, IStudentHistoryRepository studentHistoryRepository) : base(context)
  {
    this._studentHistoryRepository = studentHistoryRepository;
  }

  #endregion
}
