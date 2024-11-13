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
  /// Добавление студентов по заявкам в группу.
  /// </summary>
  /// <param name="requestsList">Список идентификаторов заявок.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификаторы заявок которые не были добавлены.</returns>
  public async Task<IEnumerable<Guid>?> AddStudentsToGroupByRequest(IEnumerable<Guid> requestsList, Guid groupId)
  {
    var group = await base.FindById(groupId);
    if(group is null)
      return null;

    var bagRequestsIds = new List<Guid>();
    foreach(var requestId in requestsList)
    {
      var request = await this._ctx.Requests.FindAsync(requestId);

      if(request?.StudentId is null || request.EducationProgramId != group.EducationProgramId || await this._studentInGroupRepository.Create(request, groupId) is null)
        bagRequestsIds.Add(requestId);
    }

    return bagRequestsIds;
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