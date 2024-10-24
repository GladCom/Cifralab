using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
  /// <summary>
  /// Репозиторий программ обучения.
  /// </summary>
  public class EducationProgramRepository : GenericRepository<EducationProgram>, IEducationProgramRepository
  {
    #region Поля и свойства
    private readonly StudentContext _studentContext;
    #endregion

    #region Методы
    #endregion

    #region Конструкторы
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст.</param>
    public EducationProgramRepository(StudentContext context) : base(context)
    {
      _studentContext = context;
    }
    #endregion
  }
}
 