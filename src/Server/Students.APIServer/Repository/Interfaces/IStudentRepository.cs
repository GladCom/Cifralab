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
  Task<PagedPage<Student>> GetStudentsByPage(int page, int pageSize);

  /// <summary>
  /// Поиск по телефону.
  /// </summary>
  /// <param name="phone">Номер телефона.</param>
  /// <returns>Студент.</returns>
  Task<Student?> FindByPhone(string phone);

  /// <summary>
  /// Поиск по электронной почте.
  /// </summary>
  /// <param name="email">Номер электронной почты.</param>
  /// <returns>Студент.</returns>
  Task<Student?> FindByEmail(string email);

  /// <summary>
  /// Поиск по номеру телефона и электронной почте.
  /// </summary>
  /// <param name="phone">Номер телефона.</param>
  /// <param name="email">Электронная почта.</param>
  /// <returns>Студент.</returns>
  Task<Student?> FindByPhoneAndEmail(string phone, string email);

  /// <summary>
  /// Список групп студента.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп студента.</returns>
  Task<IEnumerable<Group?>> GetListGroupsOfStudentExists(Guid studentId);

  /// <summary>
  /// Добавление студента в группу.
  /// </summary>
  /// <param name="stud">Идентификатор студента.</param>
  /// <param name="group">Идентификатор группы.</param>
  /// <returns>Идентификатор студента.</returns>
  Task<Guid> AddStudentToGroup(Guid stud, Guid group);


  /// <summary>
  /// Список программ обучения, на которых обучался студент.
  /// </summary>
  /// <param name="studentId">Id студента.</param>
  /// <returns>Список с программами обучения студента.</returns>
  Task<IEnumerable<EducationProgram?>?> GetListEducationProgramsOfStudentExists(Guid studentId);
}
