using Microsoft.EntityFrameworkCore;
using Students.Models;

namespace Students.DBCore.Contexts;

public abstract class StudentContext : DbContext
{
    public DbSet<EducationForm> EducationForms { get; set; }
    public DbSet<EducationProgram> EducationPrograms { get; set; }
    public DbSet<FEAProgram> FEAPrograms { get; set; }
    public DbSet<FinancingType> FinancingTypes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<ScopeOfActivity> ScopesOfActivity { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentStatus> StudentStatuses { get; set; }
    public DbSet<StudentEducation> StudentEducations { get; set; }
    public DbSet<GroupStudent> GroupStudent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		modelBuilder
		.Entity<Student>()
		.HasMany(c => c.Groups)
		.WithMany(s => s.Students)
		.UsingEntity<GroupStudent>(
			j => j
			.HasOne(pt => pt.Group)
			.WithMany(t => t.GroupStudent)
			.HasForeignKey(pt => pt.GroupsId),
		j => j
			.HasOne(pt => pt.Student)
			.WithMany(p => p.GroupStudent)
			.HasForeignKey(pt => pt.StudentsId),
		j =>
		{
			j.HasKey(t => new { t.StudentsId, t.GroupsId });
			j.ToTable("GroupStudent");
		});


		//modelBuilder.Entity<GroupStudent>()
		//	  .HasKey(m => new { m.StudentsId, m.GroupsId });

		//modelBuilder.Entity<GroupStudent>()
		//.HasOne(st => st.Student)
		//.WithMany(s => s.GroupStudent)
		//.HasForeignKey(st => st.StudentsId);

		//modelBuilder.Entity<GroupStudent>()
		//.HasOne(gr => gr.Group)
		//.WithMany(g => g.GroupStudent)
		//.HasForeignKey(gr => gr.GroupsId);


		//.UsingEntity<GroupStudent>(
		//	"PostTag",
		//	l => l.HasOne<Student>().WithMany(e => e.GroupStudent).HasForeignKey(e => e.StudentsId),
		//	r => r.HasOne<Group>().WithMany(e => e.GroupStudent).HasForeignKey(e => e.GroupsId),
		//	j => j.HasKey("StudentsId", "GroupsId"));

		//.UsingEntity<GroupStudent>(
		//       l => l.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentsId),
		//             r => r.HasOne<Group>().WithMany().HasForeignKey(e => e.GroupsId));
		//modelBuilder.Entity<GroupStudent>()
		//	.HasMany(e => e.Groups)
		//	.WithMany(e => e.Students)
		//.UsingEntity(
		//	"GroupStudent",
		// l => l.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentsId").HasPrincipalKey(nameof(Student.Id)),
		// r => r.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupsId").HasPrincipalKey(nameof(Group.Id)),
		// j => j.HasKey("StudentsId", "GroupsId"));

		//modelBuilder.Entity<Group>()
		//	.HasMany(c => c.GroupStudent)
		//	.WithRequired()
		//	.HasForeignKey(c => c.MediaId); 


		//              .HasMany(e => e.Tags)
		//.WithMany(e => e.Posts)
		//.UsingEntity(
		//	l => l.HasOne(typeof(Tag)).WithMany().HasConstraintName("TagForeignKey_Constraint"),
		//	r => r.HasOne(typeof(Post)).WithMany().HasConstraintName("PostForeignKey_Constraint"));
	}
}
