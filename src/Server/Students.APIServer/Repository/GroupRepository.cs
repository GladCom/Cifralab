using Microsoft.EntityFrameworkCore;
using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;
using Students.Models.Filters.Filters;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий групп.
/// </summary>
public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
  #region Поля и свойства

  private readonly IGroupStudentRepository _studentInGroupRepository;
  private readonly IRequestRepository _requestRepository;

  #endregion

  #region IGroupRepository

  /// <summary>
  /// Добавление студентов по заявкам в группу.
  /// </summary>
  /// <param name="requestsList">Список идентификаторов заявок.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификаторы заявок которые не были добавлены.</returns>
  public async Task<IEnumerable<Guid>?> AddStudentsToGroupByRequest(List<Guid> requestsList, Guid groupId)
  {
    var group = await this.FindById(groupId);
    if(group is null)
      return null;

    var bagRequestsIds = new List<Guid>();
    foreach(var requestId in requestsList)
    {
      var request = await this._requestRepository.FindById(requestId);

      if(request?.StudentId is null || request.EducationProgramId != group.EducationProgramId || await this._studentInGroupRepository.Create(request, groupId) is null)
        bagRequestsIds.Add(requestId);
    }

    return bagRequestsIds;
  }

  /// <summary>
  /// Удаление студентов из группы.
  /// </summary>
  /// <param name="studentList">Список идентификаторов студентов.</param>
  /// <param name="groupId">Идентификатор группы.</param>
  /// <returns>Идентификатор группы.</returns>
  public async Task<Guid?> RemoveStudentsFromGroup(List<Guid> studentList, Guid groupId)
  {
    var group = await this.FindById(groupId);
    if(group is null)
      return null;

    foreach(var studentId in studentList)
    {
      var gs = await this._studentInGroupRepository.GetOne(gs => gs.GroupId == groupId && gs.StudentId == studentId);
      if(gs is not null)
        await this._studentInGroupRepository.Remove(gs);
    }

    return groupId;
  }

  #endregion

  #region Базовый класс

  public override Task<IEnumerable<Group>> GetFiltered(Filter<Group> filter)
  {
    return this.Get(filter.GetFilterPredicate(), this.DbSet.Include(x => x.GroupStudent));
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="context">Контекст базы данных.</param>
  /// <param name="requestRepository">Репозиторий заявок.</param>
  /// <param name="studInGroupRep">Репозиторий групп студентов.</param>
  public GroupRepository(StudentContext context, IRequestRepository requestRepository, IGroupStudentRepository studInGroupRep) : base(context)
  {
    this._studentInGroupRepository = studInGroupRep;
    this._requestRepository = requestRepository;
  }

  #endregion
}