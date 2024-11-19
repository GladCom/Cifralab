using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

/// <summary>
/// Конфигурация сущности студентов.
/// </summary>
internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.HasIndex(x => x.SNILS).IsUnique();

    builder.HasIndex(x => x.Phone).IsUnique();

    builder.HasIndex(x => x.Email).IsUnique();

    builder.HasMany(c => c.Groups)
      .WithMany(s => s.Students)
      .UsingEntity<GroupStudent>(
        j => j
          .HasOne(pt => pt.Group)
          .WithMany(t => t.GroupStudent)
          .HasForeignKey(pt => pt.GroupId),
        j => j
          .HasOne(pt => pt.Student)
          .WithMany(p => p.GroupStudent)
          .HasForeignKey(pt => pt.StudentId));
  }
}