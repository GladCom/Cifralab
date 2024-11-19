using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

internal class StudentHistoryConfiguration : IEntityTypeConfiguration<StudentHistory>
{
  public void Configure(EntityTypeBuilder<StudentHistory> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.StudentId)
      .IsRequired();

    builder.Property(x => x.Family)
      .IsRequired();

    builder.HasOne(x => x.Student)
      .WithMany()
      .HasForeignKey(x => x.StudentId);
  }
}

