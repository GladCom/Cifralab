using Microsoft.EntityFrameworkCore;
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
    return await PagedPage<Student>.ToPagedPage(this._ctx.Students.Include(e=>e.Groups).Include(e=>e.Requests), page, pageSize, x => x.Family);
  }

  /// <summary>
  /// Поиск студента (с подгрузкой данных о группах и заявках) по идентификатору.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Студент.</returns>
  public async Task<Student?> GetStudentWithGroupsAndRequests(Guid studentId)
  {
    var student = await base.FindById(studentId);
    if(student is null)
      return null;

    await this._ctx.Entry(student).Collection(s => s.Groups!).LoadAsync();
    await this._ctx.Entry(student).Collection(s => s.Requests!).LoadAsync();

    return student;
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="groupStudentRepository">Репозиторий групп студентов.</param>
  public StudentRepository(StudentContext context, IGroupStudentRepository groupStudentRepository) : base(context)
  {
    this._ctx = context;
    this._studentInGroupRepository = groupStudentRepository;
  }

  #endregion
}
