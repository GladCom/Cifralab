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



  #endregion

  #region IGroupStudentRepository

  /// <summary>
  /// Добавление студента по заявке в группу.
  /// </summary>
  /// <param name="request">Заявка.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Группа студентов.</returns>
  public async Task<GroupStudent?> Create(Request request, Guid groupId)
  {
    try
    {
      return await this.Create(new GroupStudent
      {
        StudentId = request.Student!.Id,
        GroupId = groupId,
        RequestId = request.Id
      });
    }
    catch
    {
      return null;
    }
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  public GroupStudentRepository(StudentContext context) : base(context)
  {
  }

  #endregion
}