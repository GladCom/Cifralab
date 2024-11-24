using Microsoft.EntityFrameworkCore;
using Students.DBCore.Migrations;
using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Contexts;

public abstract class WorkContext : StudentContext
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    FillRealEntities(modelBuilder);
    FillReferenceEntities(modelBuilder);
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
}
