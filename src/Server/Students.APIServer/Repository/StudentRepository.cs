using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
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

  private readonly StudentContext _ctx;
  private readonly IGroupStudentRepository _studentInGroupRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Список студентов с пагинацией.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Список студентов с пагинацией.</returns>
  public async Task<PagedPage<Student>> GetStudentsByPage(int page, int pageSize)
  {
    return await PagedPage<Student>.ToPagedPage(this._ctx.Students, page, pageSize, (x) => x.Family);
  }

  /// <summary>
  /// Список групп студента.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп студента.</returns>
  public async Task<IEnumerable<Group?>?> GetListGroupsOfStudentExists(Guid studentId)
  {
    var result = from x in _ctx.Groups
      join y in _ctx.GroupStudent.Where(x => x.StudentsId == studentId).Select(s => s) on x.Id equals y.GroupsId
      select x;
    return await result.ToListAsync().ConfigureAwait(false);
  }


  /// <summary>
  /// Список программ обучения, на которых обучался студент.
  /// </summary>
  /// <param name="studentId">Id студента.</param>
  /// <returns>Список с программами обучения студента.</returns>
  public async Task<IEnumerable<EducationProgram?>?> GetListEducationProgramsOfStudentExists(Guid studentId)
  {
    var student = await base.FindById(studentId);
    if(student is null)
      return null;
    var educationPrograms = new List<EducationProgram>();
    student.Groups = new List<Group>();

    await this._ctx.Entry(student).Collection(s => s.GroupStudent).LoadAsync();

    foreach (var groupStudent in student.GroupStudent)
    {
      await this._ctx.Entry(groupStudent).Reference(s => s.Group).LoadAsync();
      student.Groups.Add(groupStudent.Group);
    }

    foreach (var studentGroup in student.Groups)
    {
      await this._ctx.Entry(studentGroup).Reference(s => s.EducationProgram).LoadAsync();
      educationPrograms.Add(studentGroup.EducationProgram);
    }

    return educationPrograms;
  }

  /// <summary>
  /// Список заявок студента.
  /// </summary>
  /// <param name="studentId">Id студента.</param>
  /// <returns>Список заявок студента.</returns>
  public async Task<IEnumerable<Request?>?> GetListRequestsOfStudentExists(Guid studentId)
  {
    var student = await base.FindById(studentId);
    if (student is null)
      return null;
    await this._ctx.Entry(student).Collection(s => s.Requests!).LoadAsync();
    return student.Requests!.ToList();
  }

  /// <summary>
  /// Добавление студента в группу.
  /// </summary>
  /// <param name="stud">Идентификатор студента.</param>
  /// <param name="group">Идентификатор группы.</param>
  /// <returns>Идентификатор студента.</returns>
  public async Task<Guid> AddStudentToGroup(Guid stud, Guid group)
  {
    await this._studentInGroupRepository.AddStudentInGroup(stud, group);
    return stud;
  }

  /// <summary>
  /// Поиск студента (с подгрузкой данных о группах и заявках) по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор студента.</param>
  /// <returns>Студент.</returns>
  public override async Task<Student?> FindById(Guid id)
  {
    return await _ctx.Students.AsNoTracking()
      .Include(x => x.Groups)
      .Include(x => x.Requests)
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  /// <summary>
  /// Поиск студента по номеру телефона.
  /// </summary>
  /// <param name="phone">Номер телефона.</param>
  /// <returns>Студент.</returns>
  public async Task<Student?> FindByPhone(string phone)
  {
    var students = this._ctx.Students.AsNoTracking().AsAsyncEnumerable();
    await foreach (var item in students)
    {
      if (item.Phone.GetPhoneFromStr().Equals(phone.GetPhoneFromStr()))
      {
        return item;
      }
    }

    return null;
  }

  /// <summary>
  /// Поиск студента по email.
  /// </summary>
  /// <param name="email">Электронная почта.</param>
  /// <returns>Студент.</returns>
  public async Task<Student?> FindByEmail(string email)
  {
    return await this._ctx.Students.AsNoTracking()
      .FirstOrDefaultAsync(x =>
        x.Email.ToLower().Equals(email.ToLower()));
  }

  /// <summary>
  /// Поиск студента по номеру телефона и email.
  /// </summary>
  /// <param name="phone">Номер телефона.</param>
  /// <param name="email">Электронная почта.</param>
  /// <returns>Студент.</returns>
  public async Task<Student?> FindByPhoneAndEmail(string phone, string email)
  {
    var students = this._ctx.Students.AsNoTracking().AsAsyncEnumerable();
    await foreach (var item in students)
    {
      if (item.Phone.GetPhoneFromStr().Equals(phone.GetPhoneFromStr())
          && item.Email.ToLower().Equals(email.ToLower()))
      {
        return item;
      }
    }

    return null;
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="studInGroupRep">Репозиторий групп студентов (это нужно удалить, заменить на репозиторий студентов).</param>
  public StudentRepository(StudentContext context, IGroupStudentRepository studInGroupRep) : base(context)
  {
    this._ctx = context;
    this._studentInGroupRepository = studInGroupRep;
  }

  #endregion
}
