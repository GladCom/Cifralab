using Students.Models;

namespace Students.APIServer.Repository
{
	public interface IGroupStudentRepository : IGenericRepository<GroupStudent>
	{
		Task<IEnumerable<GroupStudent>> GetListGroupsOfStudent(Student student);
		Task<GroupStudent> GetActualGroupOfStudent(Student student);
		Task AddStudentInGroup(Guid student, Guid groupId);
		Task AddStudentInGroup(IEnumerable<Student> student, Guid groupId);
	}
}
