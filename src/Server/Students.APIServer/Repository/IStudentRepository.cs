using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Repository;

/// <summary>
/// Интерфейс репозитория студентов
/// </summary>
public interface IStudentRepository : IGenericRepository<Student>
{
    /// <summary>
    /// Пагинация писка студентов
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <returns>Список студентов с пагинацией</returns>
    Task<PagedPage<Student>> GetStudentsByPage(int page, int pageSize);
    /// <summary>
    /// Поиск по телефону
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    /// <returns>Студент</returns>
    Task<Student?> FindByPhone(string phone);
    /// <summary>
    /// Поиск по электронной почте
    /// </summary>
    /// <param name="Email">Номер электронноый почты</param>
    /// <returns>Студент</returns>
    Task<Student?> FindByEmail(string Email);
    /// <summary>
    /// Поиск по номеру телефона и электронной почте
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    /// <param name="Email">Электронная почта</param>
    /// <returns>Студент</returns>
    Task<Student?> FindByPhoneAndEmail(string phone, string Email);
    /// <summary>
    /// Список групп студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента</param>
    /// <returns>Список групп студента</returns>
    Task<IEnumerable<Group?>> GetListGroupsOfStudentExists(Guid studentId);
    /// <summary>
    /// Добавление студента в группу
    /// </summary>
    /// <param name="stud">Идентифитокар студента</param>
    /// <param name="group">Идентификатор группы</param>
    /// <returns>Идентифкатор студента</returns>
    Task<Guid> AddStudentToGroup(Guid stud, Guid group);

}
