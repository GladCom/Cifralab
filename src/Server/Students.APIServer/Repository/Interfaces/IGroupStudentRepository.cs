using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория групп студентов.
/// </summary>
public interface IGroupStudentRepository : IGenericRepository<GroupStudent>
{
  /// <summary>
  /// Добавление студента по заявке в группу.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Группа студентов.</returns>
  Task<GroupStudent?> Create(Request request, Guid groupId);
}