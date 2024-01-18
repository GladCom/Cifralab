using Students.Models;

namespace Students.APIServer.Repository
{
	public interface IGroupRepository : IGenericRepository<Group>
	{
		Task<Guid> AddStudentsInGroup(IEnumerable<Student> students, Guid groupId);
	}
}
