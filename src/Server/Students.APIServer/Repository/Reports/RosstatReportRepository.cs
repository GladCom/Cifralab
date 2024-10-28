using Students.APIServer.Repository.Interfaces;
using Students.Models;
using Students.Models.ReportsModel;

namespace Students.APIServer.Repository.Reports;

/// <summary>
/// Репозиторий.
/// </summary>
public class RosstatReportRepository : IReportRepository<RosstatModel>
{
  #region Поля и свойства

  private readonly IStudentRepository _studentRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <returns>Список сущностей.</returns>
  public async Task<List<RosstatModel>> Get()
  {
    var listStudents = await _studentRepository.Get();
    return new List<RosstatModel>() { new() { StudentCount = listStudents.Count() } };
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="studentRepository">Репозиторий студентов.</param>
  public RosstatReportRepository(IStudentRepository studentRepository)
  {
    _studentRepository = studentRepository;
  }

  #endregion
}