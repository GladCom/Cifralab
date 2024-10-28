using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration;

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

    builder.HasOne(s => s.Student)
      .WithMany(r => r.Requests)
      .HasForeignKey(s => s.StudentId);

    builder.HasOne(ep => ep.EducationProgram)
      .WithMany()
      .HasForeignKey(ep => ep.EducationProgramId);

    builder.HasOne(d => d.DocumentRiseQualification)
      .WithMany()
      .HasForeignKey(d => d.DocumentRiseQualificationId);

    builder.HasMany(o => o.Orders)
      .WithOne(r => r.Request)
      .HasForeignKey(r => r.RequestId);

    builder.HasOne(ep => ep.Status)
      .WithMany()
      .HasForeignKey(ep => ep.StatusRequestId);

    builder.HasOne(ep => ep.StudentStatus)
      .WithMany()
      .HasForeignKey(ep => ep.StudentStatusId);
  }
}