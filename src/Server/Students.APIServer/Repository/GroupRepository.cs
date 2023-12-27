using Microsoft.AspNetCore.Mvc.ModelBinding;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
	public class GroupRepository : GenericRepository<Group>, IGroupRepository
	{
		private readonly StudentContext _ctx;
		private IStudentInGroupRepository _studentInGroupRepository;

		public GroupRepository(StudentContext context, IStudentInGroupRepository studInGroupRep) : base(context)
		{
			_ctx = context;
			_studentInGroupRepository = studInGroupRep;
		}

		public async Task<Guid> AddStudentsInGroup(IEnumerable<Student> students, Guid groupId)
		{
			await _studentInGroupRepository.AddStudentInGroup(students, groupId);
			return groupId;
		}
	}
}