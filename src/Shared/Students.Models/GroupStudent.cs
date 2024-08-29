using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Students.Models
{
	public class GroupStudent
    {
		public Guid StudentsId { get; set; }

		public Guid GroupsId { get; set; }

		public virtual Student? Student { get; set; }

		public virtual Group? Group { get; set; }
	}
}
