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
      .Include(gs => gs.GroupStudent!)
        .ThenInclude(r => r.Request!)
          .ThenInclude(st => st.Status)
      .Include(gs1 => gs1.GroupStudent!)
        .ThenInclude(g => g.Group!)
          .ThenInclude(e => e.EducationProgram)
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

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="groupStudentRepository">Репозиторий групп студентов.</param>
  public StudentRepository(StudentContext context) : base(context)
  {
  }

  #endregion
}
