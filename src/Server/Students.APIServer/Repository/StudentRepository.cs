using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension.Pagination;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly StudentContext _ctx;
    public StudentRepository(StudentContext context) : base(context)
    {
        _ctx = context;
    }

    public async Task<PagedPage<Student>> GetStudentsByPage(int page, int pageSize)
    {
        return await  PagedPage<Student>.ToPagedPage(_ctx.Students, page, pageSize);

    }

    public async Task<Student?> FindById(Guid id)
    {
        return await _ctx.Students.AsNoTracking()
            .Include(x=>x.Groups)
            .Include(x=>x.Requests)
            .FirstOrDefaultAsync(x=>x.Id == id);

    }
}