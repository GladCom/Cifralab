using Students.Models;

namespace Students.APIServer.Repository
{
	public interface IStudentInGroupRepository : IGenericRepository<StudentInGroup>
	{
		Task<IEnumerable<StudentInGroup>> GetListGroupsOfStudent(Student student);
		Task<StudentInGroup> GetActualGroupOfStudent(Student student);
		Task AddStudentInGroup(Guid student, Guid groupId);
		Task AddStudentInGroup(IEnumerable<Student> student, Guid groupId);
	}
}
