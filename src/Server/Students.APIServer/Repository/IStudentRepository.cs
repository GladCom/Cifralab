using Students.APIServer.Extension.Pagination;
using Students.Models;

namespace Students.APIServer.Repository;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task <PagedPage<Student>> GetStudentsByPage(int page, int pageSize);
}