using Microsoft.EntityFrameworkCore;
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
      .Include(x => x.Requests));
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
