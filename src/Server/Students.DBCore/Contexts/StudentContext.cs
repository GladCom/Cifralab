using Microsoft.EntityFrameworkCore;
using Students.Models;

namespace Students.DBCore.Contexts;

public abstract class StudentContext : DbContext
{
    public DbSet<EducationForm> EducationForms { get; set; }
    public DbSet<EducationProgram> EducationPrograms { get; set; }
    public DbSet<EducationType> EducationTypes { get; set; }
    public DbSet<FEAProgram> FEAPrograms { get; set; }
    public DbSet<FinancingType> FinancingTypes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<ScopeOfActivity> ScopesOfActivity { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentStatus> StudentStatuses { get; set; }
    public DbSet<StudentEducation> StudentEducations { get; set; }
    public DbSet<StudentDocument> StudentDocuments { get; set; }
    public DbSet<GroupStudent> GroupStudent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<GroupStudent>()
			  .HasKey(m => new { m.StudentsId, m.GroupsId });
	}
}
