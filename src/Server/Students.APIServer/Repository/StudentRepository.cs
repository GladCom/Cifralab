using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
using Students.APIServer.Extension.Pagination;
using Students.DBCore.Contexts;
using Students.Models;
using System.Collections;

namespace Students.APIServer.Repository;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly StudentContext _ctx;
	private IGroupStudentRepository _studentInGroupRepository;
	public StudentRepository(StudentContext context, IGroupStudentRepository studInGroupRep) : base(context) {
        _ctx = context;
		_studentInGroupRepository = studInGroupRep;
	}

    public async Task<PagedPage<Student>> GetStudentsByPage(int page, int pageSize)
    {
        return await  PagedPage<Student>.ToPagedPage(_ctx.Students, page, pageSize);
    }

	//public async Group? GetCurrentGroupOfStudent(Student student)
	//{
 //       return await _ctx.Groups.AsNoTracking()
 //           .FirstOrDefaultAsync(x=>x);
	//}
	public async Task<IEnumerable<Group?>> GetListGroupsOfStudentExists(Guid studentId) {
         var result = from x in _ctx.Groups
                     join y in _ctx.GroupStudent.Where(x => x.StudentsId == studentId).Select(s => s)
                     on x.Id equals y.GroupsId
                     select x;

        return await result.ToListAsync().ConfigureAwait(false);
	}
    public async Task<Guid> AddStudentToGroup(Guid stud, Guid group){
		await _studentInGroupRepository.AddStudentInGroup(stud, group);
        return stud;
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
		var students = _ctx.Students.AsNoTracking().AsAsyncEnumerable();
		await foreach (var item in students)
		{
			if (item.Phone.GetPhoneFromStr().Equals(phone.GetPhoneFromStr()))
			{
				return item;
			}
		}
		return null;
	}
    public async Task<Student?> FindByEmail(string email)
    {
        return await _ctx.Students.AsNoTracking()
            .FirstOrDefaultAsync(x => 
            x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<Student?> FindByPhoneAndEmail(string phone, string email)
    {
        var students = _ctx.Students.AsNoTracking().AsAsyncEnumerable();
        await foreach (var item in students)
        {
            if (item.Phone.GetPhoneFromStr().Equals(phone.GetPhoneFromStr())
                && (item.Email.ToLower().Equals(email.ToLower())))
            {
                return item;
            }
        }
        return null;
    }
}
