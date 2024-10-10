using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс репозитория групп студентов (необходимо удалить)
/// </summary>
public interface IGroupStudentRepository : IGenericRepository<GroupStudent>
{
  /// <summary>
  /// Список групп студентов
  /// </summary>
  /// <param name="student">Студент</param>
  /// <returns>Список групп студентов</returns>
  Task<IEnumerable<GroupStudent>> GetListGroupsOfStudent(Student student);

  /// <summary>
  /// Актуальная группа студента
  /// </summary>
  /// <param name="student">Студент</param>
  /// <returns>Группа студентов</returns>
  Task<GroupStudent?> GetActualGroupOfStudent(Student student);

  /// <summary>
  /// Добавление студент в группу
  /// </summary>
  /// <param name="student">Идентификатор студента</param>
  /// <param name="groupId">Идентификатор группы</param>
  /// <returns></returns>
  Task AddStudentInGroup(Guid student, Guid groupId);

  /// <summary>
  /// Добавление студентов в группу
  /// </summary>
  /// <param name="student">Список студентов</param>
  /// <param name="groupId">Идентификатор группы</param>
  /// <returns></returns>
  Task AddStudentInGroup(IEnumerable<Student> student, Guid groupId);
}