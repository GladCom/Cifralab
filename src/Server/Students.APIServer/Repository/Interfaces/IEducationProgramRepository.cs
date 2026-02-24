using Students.Models;

namespace Students.APIServer.Repository.Interfaces;

/// <summary>
/// Интерфейс программы обучения.
/// </summary>
public interface IEducationProgramRepository : IGenericRepository<EducationProgram>, ISearchRepository<EducationProgram, EducationProgram>
{
  /// <summary>
  /// Поменять статус признака Архив.
  /// </summary>
  /// <param name="educationProgramId">Идентификатор.</param>
  /// <returns>Программа обучения.</returns>
  Task<EducationProgram?> MoveToArchiveOrBack(Guid educationProgramId);
}