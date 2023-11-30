using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
using Students.APIServer.Extension.Pagination;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly StudentContext _ctx;
    public StudentRepository(StudentContext context) : base(context) {
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
    public async Task<Student?> FindByPhone(string phone)
    {
        return await _ctx.Students.AsNoTracking()
            .FirstOrDefaultAsync(x =>
            (x.Phone.GetPhoneFromStr()).Equals((phone.GetPhoneFromStr())));
    }
    public async Task<Student?> FindByEmail(string email)
    {
        return await _ctx.Students.AsNoTracking()
            .FirstOrDefaultAsync(x => 
            x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<Student?> FindByPhoneAndEmail(string phone, string email)
    {
        return await _ctx.Students.AsNoTracking()
            .FirstOrDefaultAsync(x =>
            (x.Phone.GetPhoneFromStr()).Equals((phone.GetPhoneFromStr()))
          &&(x.Email.ToLower().Equals(email.ToLower())));
    }
}
