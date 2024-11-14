using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models.ReferenceModels;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий ВЭД программ.
/// </summary>
public class FEAProgramRepository : GenericRepository<FEAProgram>, IFEAProgramRepository
{
  #region Поля и свойства


  #endregion

  #region IFEAProgramRepository



  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  public FEAProgramRepository(StudentContext context) : base(context)
  {
  }

  #endregion
}