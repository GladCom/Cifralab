using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс программы обучения.
/// </summary>
public interface IEducationProgramRepository
{
  /// <summary>
  /// Список программ обучения, на которых обучался студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список программам обучения.</returns>
  Task<IEnumerable<EducationProgram?>?> GetListEducationProgramsOfStudentExists(Guid studentId);
}