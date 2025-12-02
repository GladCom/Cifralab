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

  /// <summary>
  /// Студент проходил обучение в этом году.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="requestId">Идентификатор заявки, для которой производиться проверка.</param>
  Task<bool> IsAlreadyStudied(Guid studentId, Guid requestId);
  
  /// <summary>
  /// Зачисление в группу по заявке.
  /// </summary>
  /// <param name="id">ID заявки.</param>
  /// <param name="groupId">ID группы.</param>
  /// <returns></returns>
  Task Enrollment(Guid studentId, Guid requestId, Guid groupId);
}
