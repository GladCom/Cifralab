using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория групп.
/// </summary>
public interface IGroupRepository : IGenericRepository<Group>
{
  /// <summary>
  /// Добавление студентов в группу.
  /// </summary>
  /// <param name="studentsList">Список студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  Task<Guid> AddStudentsToGroup(IEnumerable<Student> studentsList, Guid groupId);

  /// <summary>
  /// Добавление студента в группу.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор студента.</returns>
  Task<Guid> AddStudentToGroup(Guid studentId, Guid groupId);

  /// <summary>
  /// Список групп, в которых состоит студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп.</returns>
  Task<IEnumerable<Group?>?> GetListGroupsOfStudentExists(Guid studentId);
}