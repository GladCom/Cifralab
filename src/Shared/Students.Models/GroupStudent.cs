namespace Students.Models
{
	/// <summary>
	/// Группа студентов (данный класс должен умереть)
	/// </summary>
	public class GroupStudent
	{
		/// <summary>
		/// Идентификатор студента
		/// </summary>
		public Guid StudentsId { get; set; }
		/// <summary>
		/// Ижентификатор группы
		/// </summary>

		public Guid GroupsId { get; set; }
		/// <summary>
		/// Студент (навигационное свойство)
		/// </summary>

		public virtual Student? Student { get; set; }
        /// <summary>
        /// Группа (навигационное свойство)
        /// </summary>

        public virtual Group? Group { get; set; }
	}
}
