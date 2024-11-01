using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий групп.
/// </summary>
public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
  #region Поля и свойства

  private readonly StudentContext _ctx;
  private readonly IGroupStudentRepository _studentInGroupRepository;

  #endregion

  #region Методы

  /// <summary>
  /// Добавление студентов в группу.
  /// </summary>
  /// <param name="studentsList">Список студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  public async Task<Guid> AddStudentsToGroup(IEnumerable<Student> studentsList, Guid groupId)
  {
    foreach(var student in studentsList)
    {
      await this._studentInGroupRepository.Create(new GroupStudent { StudentsId = student.Id, GroupsId = groupId });
    }
    return groupId;
  }

  /// <summary>
  /// Добавление студента в группу.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор студента.</returns>
  public async Task<Guid> AddStudentToGroup(Guid studentId, Guid groupId)
  {
    await this._studentInGroupRepository.Create(new GroupStudent { StudentsId = studentId, GroupsId = groupId });
    return studentId;
  }

  /// <summary>
  /// Список групп, в которых состоит студент.
  /// </summary>
  /// <param name="studentId">Идентификатор студента.</param>
  /// <returns>Список групп.</returns>
  public async Task<IEnumerable<Group?>?> GetListGroupsOfStudentExists(Guid studentId)
  {
    var student = await this._ctx.FindAsync<Student>(studentId);

    if(student is null)
      return null;

    await this._ctx.Entry(student).Collection(s => s.Groups!).LoadAsync();

    return student.Groups;
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="studInGroupRep">Репозиторий групп студентов.</param>
  public GroupRepository(StudentContext context, IGroupStudentRepository studInGroupRep) : base(context)
  {
    this._ctx = context;
    this._studentInGroupRepository = studInGroupRep;
  }

  #endregion
}