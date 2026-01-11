using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс истории студента.
/// </summary>
public interface IStudentHistoryRepository : IGenericRepository<StudentHistory>
{
  /// <summary>
  /// Сравнить студентов по ключевым полям и при наличии различий добавить их в историю.
  /// </summary>
  /// <param name="oldStudent">Старый студент.</param>
  /// <param name="newStudent">Новый студент.</param>
  /// <returns>История изменений студента.</returns>
  Task<StudentHistory?> CreateStudentHistory(Student oldStudent, Student newStudent);
}

