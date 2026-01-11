using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

internal class RequestConfiguration : IEntityTypeConfiguration<Request>
{
  public void Configure(EntityTypeBuilder<Request> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.Email)
      .IsRequired();

    builder.Property(x => x.Phone)
      .IsRequired();

    builder.Property(x => x.Agreement)
      .IsRequired();

    builder.HasIndex(r => r.DocumentRiseQualificationId)
      .IsUnique();

    builder.HasOne(r => r.Student)
      .WithMany(s => s.Requests)
      .HasForeignKey(r => r.StudentId);

    builder.HasOne(r => r.PhantomStudent)
      .WithOne()
      .HasForeignKey<Request>(r => r.PhantomStudentId);

    builder.HasOne(r => r.EducationProgram)
      .WithMany(ep => ep.Requests)
      .HasForeignKey(r => r.EducationProgramId);

    builder.HasOne(r => r.DocumentRiseQualification)
      .WithMany()
      .HasForeignKey(r => r.DocumentRiseQualificationId);

    builder.HasOne(r => r.Status)
      .WithMany()
      .HasForeignKey(r => r.StatusRequestId);

    builder.HasOne(r => r.StudentStatus)
      .WithMany()
      .HasForeignKey(r => r.StudentStatusId);
  }
}