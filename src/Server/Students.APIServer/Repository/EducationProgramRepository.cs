using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий программ обучения.
/// </summary>
public class EducationProgramRepository : GenericRepository<EducationProgram>, IEducationProgramRepository
{
  #region Поля и свойства

  private readonly StudentContext _ctx;

  #endregion

  #region Методы

  /// <summary>
  /// Список программ обучения, на которых обучался студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список программам обучения.</returns>
  public async Task<IEnumerable<EducationProgram?>?> GetListEducationProgramsOfStudentExists(Guid studentId)
  {
    var student = await this._ctx.Students.FindAsync(studentId);
    if(student is null)
      return null;

    await this._ctx.Entry(student).Collection(s => s.Groups!).LoadAsync();

    foreach(var studentGroup in student.Groups!)
    {
      await this._ctx.Entry(studentGroup).Reference(s => s.EducationProgram).LoadAsync();
    }

    return student.Groups.Select(g => g.EducationProgram);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст.</param>
  public EducationProgramRepository(StudentContext context) : base(context)
  {
    this._ctx = context;
  }

  #endregion
}