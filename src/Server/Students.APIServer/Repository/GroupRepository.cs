using Students.APIServer.Repository.Interfaces;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Репозиторий групп
/// </summary>
public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
  private readonly StudentContext _ctx;
  private IGroupStudentRepository _studentInGroupRepository;

  /// <summary>
  /// Конструктор
  /// </summary>
  /// <param name="context">Контекст базы данных</param>
  /// <param name="studInGroupRep">Репозиторий групп студентов</param>
  public GroupRepository(StudentContext context, IGroupStudentRepository studInGroupRep) : base(context)
  {
    _ctx = context;
    _studentInGroupRepository = studInGroupRep;
  }

  /// <summary>
  /// Добавление студентов в группу
  /// </summary>
  /// <param name="students">Список студентов</param>
  /// <param name="groupId">Идентификатор группы</param>
  /// <returns>Идентификатор группы</returns>
  public async Task<Guid> AddStudentsInGroup(IEnumerable<Student> students, Guid groupId)
  {
    await _studentInGroupRepository.AddStudentInGroup(students, groupId);
    return groupId;
  }
}