using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий групп студентов.
/// </summary>
public class GroupStudentRepository : GenericRepository<GroupStudent>, IGroupStudentRepository
{
  #region Поля и свойства

  private readonly StudentContext _ctx;

  #endregion

  #region Методы



  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  public GroupStudentRepository(StudentContext context) : base(context)
  {
    this._ctx = context;
  }

  #endregion
}