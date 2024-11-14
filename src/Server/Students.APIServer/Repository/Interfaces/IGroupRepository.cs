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
  Task<IEnumerable<Guid>?> AddStudentsToGroupByRequest(List<Guid> requestsList, Guid groupId);

  /// <summary>
  /// Удаление студентов из группы.
  /// </summary>
  /// <param name="studentList">Список идентификаторов студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  Task<Guid?> RemoveStudentsFromGroup(List<Guid> studentList, Guid groupId);
}