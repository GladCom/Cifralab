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
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.Surname)
      .IsRequired();

    builder.Property(x => x.BirthDate)
      .IsRequired();

    builder.Property(x => x.Sex)
      .IsRequired();

    builder.Property(x => x.Address)
      .IsRequired();

    builder.Property(x => x.Phone)
      .IsRequired();

    builder.Property(x => x.Email)
      .IsRequired();

    builder.Property(x => x.IT_Experience);

    builder.Property(x => x.ScopeOfActivityLevelOneId)
      .IsRequired();

    builder.HasIndex(x => x.SNILS).IsUnique();

    builder.HasIndex(x => x.Phone).IsUnique();

    builder.HasIndex(x => x.Email).IsUnique();

    builder.HasOne(s => s.TypeEducation)
      .WithMany()
      .HasForeignKey(s => s.TypeEducationId);

    builder.HasOne(s => s.ScopeOfActivityLevelOne)
      .WithMany()
      .HasForeignKey(s => s.ScopeOfActivityLevelOneId);

    builder.HasOne(s => s.ScopeOfActivityLevelTwo)
      .WithMany()
      .HasForeignKey(s => s.ScopeOfActivityLevelTwoId);

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