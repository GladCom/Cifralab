using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория групп.
/// </summary>
public interface IGroupRepository : IGenericRepository<Group>
{
  /// <summary>
  /// Добавление студентов по заявкам в группу.
  /// </summary>
  /// <param name="requestsList">Список идентификаторов заявок.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификаторы заявок которые не были добавлены.</returns>
  Task<IEnumerable<Guid>?> AddStudentsToGroupByRequest(IEnumerable<Guid> requestsList, Guid groupId);

  /// <summary>
  /// Список групп, в которых состоит студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп.</returns>
  Task<IEnumerable<Group?>?> GetListGroupsOfStudentExists(Guid studentId);
}