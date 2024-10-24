using Students.Models.ReferenceModels;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс истории студента.
/// </summary>
public interface IStudentHistoryRepository : IGenericRepository<StudentHistory>
{
  /// <summary>
  /// Получить историю студента.
  /// </summary>
  /// <param name="studentId">Id студента.</param>
  /// <returns>Список изменений студента.</returns>
  Task<IEnumerable<StudentHistory>> GetListChangesByStudentIdAsync(Guid studentId);
}

