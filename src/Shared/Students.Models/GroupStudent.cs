using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Students.Models
{
	public class GroupStudent
    {
		//[Key]
		//[Column(Order = 0)]
		//[ForeignKey("Student")]
		public Guid StudentsId { get; set; }
		//[Key]
		//[Column(Order = 1)]
		//[ForeignKey("Group")]
		public Guid GroupsId { get; set; }

		public virtual Student? Student { get; set; }
		public virtual Group? Group { get; set; }
	}
}
