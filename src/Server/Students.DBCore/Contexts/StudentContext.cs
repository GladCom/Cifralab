using Microsoft.EntityFrameworkCore;
using Students.DBCore.Confuguration;
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
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new EducationProgramConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentRiseQualificationConfiguration());
        modelBuilder.ApplyConfiguration(new EducationFormConfiguration());
        //modelBuilder.ApplyConfiguration(new EducationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FEAProgramConfiguration());
        modelBuilder.ApplyConfiguration(new FinancingTypeConfiguration());
        modelBuilder.ApplyConfiguration(new KindDocumentRiseQualificationConfiguration());
        modelBuilder.ApplyConfiguration(new KindOrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new RequestConfiguration());
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
    }
}
