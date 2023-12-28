using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
	public class GroupStudentRepository : GenericRepository<GroupStudent>, IGroupStudentRepository
	{
		private readonly StudentContext _ctx;

		public GroupStudentRepository(StudentContext context) : base(context)
		{
			_ctx = context;
		}

		public async Task AddStudentInGroup(Guid student, Guid groupId)
		{
			_ctx.GroupStudent.Add(new GroupStudent { StudentsId = student, GroupsId = groupId });
			 await _ctx.SaveChangesAsync();
		}

		public async Task AddStudentInGroup(IEnumerable<Student> students, Guid groupId)
		{
			foreach (var item in students) {
				_ctx.GroupStudent.Add(new GroupStudent { StudentsId = item.Id, GroupsId = groupId });
			}
			await _ctx.SaveChangesAsync();
		}

		public async Task<GroupStudent> GetActualGroupOfStudent(Student student)
		{
			return await _ctx.GroupStudent.AsNoTracking().FirstOrDefaultAsync(x => x.StudentsId == student.Id);
		}

		public async Task<IEnumerable<GroupStudent>> GetListGroupsOfStudent(Student student)
		{
			return await _ctx.GroupStudent.AsNoTracking().Where(x => x.StudentsId == student.Id).ToListAsync();
				//.SelectAsync(async x=> await (x));
		}
	}
}
