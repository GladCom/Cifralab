using Students.APIServer.DTO;
using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория студентов.
/// </summary>
public interface IStudentRepository : IGenericRepository<Student>
{
  /// <summary>
  /// Пагинация писка студентов.
  /// </summary>
  /// <param name="page">Номер страницы.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Список студентов с пагинацией.</returns>
  Task<PagedPage<StudentDTO>> GetStudentsByPage(int page, int pageSize);

  /// <summary>
  /// Поиск студента (с подгрузкой данных о группах и заявках) по идентификатору.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Студент.</returns>
  Task<Student?> GetStudentWithGroupsAndRequests(Guid studentId);
}
