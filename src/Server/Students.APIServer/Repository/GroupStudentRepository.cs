using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Students.APIServer.Extension;
using Students.DBCore.Contexts;
using Students.Models;

namespace Students.APIServer.Repository
{
	/// <summary>
	/// Репозиторий групп студентов
	/// </summary>
	public class GroupStudentRepository : GenericRepository<GroupStudent>, IGroupStudentRepository
	{
		private readonly StudentContext _ctx;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="context">Контекст базы данных</param>
		public GroupStudentRepository(StudentContext context) : base(context)
		{
			_ctx = context;
		}

        /// <summary>
        /// Добавление студента в группу
        /// </summary>
        /// <param name="student">Идентификатор студента</param>
        /// <param name="groupId">Иднтификатор группы</param>
        /// <returns></returns>
        public async Task AddStudentInGroup(Guid student, Guid groupId)
		{
			_ctx.GroupStudent.Add(new GroupStudent { StudentsId = student, GroupsId = groupId });
			 await _ctx.SaveChangesAsync();
		}

        /// <summary>
        /// Добавление студентов в группу
        /// </summary>
        /// <param name="students">студента</param>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns></returns>
        public async Task AddStudentInGroup(IEnumerable<Student> students, Guid groupId)
		{
			foreach (var item in students) {
				_ctx.GroupStudent.Add(new GroupStudent { StudentsId = item.Id, GroupsId = groupId });
			}
			await _ctx.SaveChangesAsync();
		}

		/// <summary>
		/// Актуальная группа студента
		/// </summary>
		/// <param name="student">Студент</param>
		/// <returns>Студент</returns>
		public async Task<GroupStudent> GetActualGroupOfStudent(Student student)
		{
			return await _ctx.GroupStudent.AsNoTracking().FirstOrDefaultAsync(x => x.StudentsId == student.Id);
		}

		/// <summary>
		/// Список групп студента
		/// </summary>
		/// <param name="student">Студент</param>
		/// <returns>Список групп студента</returns>
		public async Task<IEnumerable<GroupStudent>> GetListGroupsOfStudent(Student student)
		{
			return await _ctx.GroupStudent.AsNoTracking().Where(x => x.StudentsId == student.Id).ToListAsync();
				//.SelectAsync(async x=> await (x));
		}
	}
}
