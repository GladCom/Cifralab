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
  /// <param name="students">Список студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  Task<Guid> AddStudentsInGroup(IEnumerable<Student> students, Guid groupId);
}