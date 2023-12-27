using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
	public class StudentInGroupRepository : GenericRepository<StudentInGroup>, IStudentInGroupRepository
	{
		private readonly StudentContext _ctx;

		public StudentInGroupRepository(StudentContext context) : base(context)
		{
			_ctx = context;
		}

		public async Task AddStudentInGroup(Guid student, Guid groupId)
		{
			_ctx.StudentInGroups.Add(new StudentInGroup { StudentId = student, GroupId = groupId });
			 await _ctx.SaveChangesAsync();
		}

		public async Task AddStudentInGroup(IEnumerable<Student> students, Guid groupId)
		{
			foreach (var item in students) {
				_ctx.StudentInGroups.Add(new StudentInGroup { StudentId = item.Id, GroupId = groupId });
			}
			await _ctx.SaveChangesAsync();
		}

		public async Task<StudentInGroup> GetActualGroupOfStudent(Student student)
		{
			return await _ctx.StudentInGroups.AsNoTracking().FirstOrDefaultAsync(x => x.StudentId == student.Id);
		}

		public async Task<IEnumerable<StudentInGroup>> GetListGroupsOfStudent(Student student)
		{
			return await _ctx.StudentInGroups.AsNoTracking().Where(x => x.StudentId == student.Id).ToListAsync();
				//.SelectAsync(async x=> await (x));
		}
	}
}
