using Students.Models;

namespace Students.APIServer.Repository;

public interface IStudentRepository : IGenericRepository<Student>
{
    IEnumerable<Student> GetStudentsByPage(int page, int pageSize);
}