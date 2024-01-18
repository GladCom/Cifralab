using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Repository;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task <PagedPage<Student>> GetStudentsByPage(int page, int pageSize);
    Task<Student> FindByPhone(string phone);
    Task<Student> FindByEmail(string Email);
    Task<Student> FindByPhoneAndEmail(string phone, string Email);
    Task<IEnumerable<Group?>> GetListGroupsOfStudentExists(Guid studentId);
    Task<Guid> AddStudentToGroup(Guid stud, Guid group);

}
