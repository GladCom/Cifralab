using Microsoft.EntityFrameworkCore;
using Students.DBCore.Configuration;
using Students.DBCore.Migrations;
using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Contexts;

public abstract class StudentContext : DbContext
{
  public DbSet<EducationForm> EducationForms { get; set; }

  public DbSet<EducationProgram> EducationPrograms { get; set; }
  public DbSet<KindEducationProgram> KindEducationPrograms { get; set; }
  //public DbSet<EducationType> EducationTypes { get; set; }
  public DbSet<FEAProgram> FEAPrograms { get; set; }
  public DbSet<FinancingType> FinancingTypes { get; set; }
  public DbSet<Group> Groups { get; set; }
  public DbSet<Request> Requests { get; set; }
  public DbSet<ScopeOfActivity> ScopesOfActivity { get; set; }
  public DbSet<Student> Students { get; set; }

  public DbSet<StudentStatus> StudentStatuses { get; set; }

  //public DbSet<StudentDocument> StudentDocuments { get; set; }
  public DbSet<StudentHistory> StudentHistories { get; set; }
  public DbSet<GroupStudent> GroupStudent { get; set; }
  public DbSet<TypeEducation> TypeEducation { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<KindOrder> KindOrders { get; set; }
  public DbSet<KindDocumentRiseQualification> KindDocumentRiseQualifications { get; set; }
  public DbSet<DocumentRiseQualification> DocumentRiseQualifications { get; set; }
  public DbSet<StatusRequest> StatusRequests { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    MakeModelsConfiguration(modelBuilder);
    FillReferenceEntities(modelBuilder);
    FillRealEntities(modelBuilder);
  }

  private static void MakeModelsConfiguration(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new GroupConfiguration());
    modelBuilder.ApplyConfiguration(new GroupStudentConfiguration());
    modelBuilder.ApplyConfiguration(new StudentConfiguration());
    modelBuilder.ApplyConfiguration(new EducationProgramConfiguration());
    modelBuilder.ApplyConfiguration(new DocumentRiseQualificationConfiguration());
    modelBuilder.ApplyConfiguration(new EducationFormConfiguration());
    modelBuilder.ApplyConfiguration(new TypeEducationConfiguration());
    modelBuilder.ApplyConfiguration(new FEAProgramConfiguration());
    modelBuilder.ApplyConfiguration(new FinancingTypeConfiguration());
    modelBuilder.ApplyConfiguration(new KindDocumentRiseQualificationConfiguration());
    modelBuilder.ApplyConfiguration(new KindOrderConfiguration());
    modelBuilder.ApplyConfiguration(new OrderConfiguration());
    modelBuilder.ApplyConfiguration(new RequestConfiguration());
    modelBuilder.ApplyConfiguration(new ScopeOfActivityConfiguration());
    modelBuilder.ApplyConfiguration(new StatusRequestConfiguration());
    modelBuilder.ApplyConfiguration(new StudentHistoryConfiguration());
    modelBuilder.ApplyConfiguration(new KindEducationProgramConfiguration());
  }

  private static void FillReferenceEntities(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<FEAProgram>().HasData(HasDataEntities.FEAProgramEntities);
    modelBuilder.Entity<FinancingType>().HasData(HasDataEntities.FinancingTypeEntities);
    modelBuilder.Entity<EducationForm>().HasData(HasDataEntities.EducationFormEntities);
    modelBuilder.Entity<KindDocumentRiseQualification>().HasData(HasDataEntities.KindDocumentRiseQualificationEntities);
    modelBuilder.Entity<KindOrder>().HasData(HasDataEntities.KindOrderEntities);
    modelBuilder.Entity<KindEducationProgram>().HasData(HasDataEntities.KindEducationProgramEntities);
    modelBuilder.Entity<ScopeOfActivity>().HasData(HasDataEntities.ScopeOfActivityEntities);
    modelBuilder.Entity<StatusRequest>().HasData(HasDataEntities.StatusRequestEntities);
    modelBuilder.Entity<StudentStatus>().HasData(HasDataEntities.StudentStatusEntities);
    modelBuilder.Entity<TypeEducation>().HasData(HasDataEntities.TypeEducationEntities);
  }

  private static void FillRealEntities(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<DocumentRiseQualification>().HasData(HasDataEntities.DocumentRiseQualificationEntities);
    modelBuilder.Entity<EducationProgram>().HasData(HasDataEntities.EducationProgramEntities);
    modelBuilder.Entity<Group>().HasData(HasDataEntities.GroupEntities);
    modelBuilder.Entity<GroupStudent>().HasData(HasDataEntities.GroupStudentEntities);
    modelBuilder.Entity<Order>().HasData(HasDataEntities.OrderEntities);
    modelBuilder.Entity<Request>().HasData(HasDataEntities.RequestEntities);
    modelBuilder.Entity<Student>().HasData(HasDataEntities.StudentEntities);
  }
}
