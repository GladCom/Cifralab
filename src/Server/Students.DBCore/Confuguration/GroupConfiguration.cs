using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration;

/// <summary>
/// Конфигурация сущности группы.
/// </summary>
internal class GroupConfiguration : IEntityTypeConfiguration<Group>
{
  public void Configure(EntityTypeBuilder<Group> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.EducationProgramId)
      .IsRequired();

    builder.Property(x => x.StartDate)
      .IsRequired();

    builder.Property(x => x.EndDate)
      .IsRequired();

    builder.HasOne(ep => ep.EducationProgram)
      .WithMany(g => g.Groups)
      .HasForeignKey(ep => ep.EducationProgramId);
  }
}