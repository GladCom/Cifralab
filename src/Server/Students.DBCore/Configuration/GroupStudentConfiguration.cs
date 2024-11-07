using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

internal class GroupStudentConfiguration : IEntityTypeConfiguration<GroupStudent>
{
  public void Configure(EntityTypeBuilder<GroupStudent> builder)
  {
    builder.HasKey(t => t.RequestId);

    builder.HasIndex(t => new { t.GroupId, t.StudentId })
      .IsUnique();

    builder.ToTable("GroupStudent");

    builder.Property(x => x.RequestId)
      .IsRequired();

    builder.Property(x => x.GroupId)
      .IsRequired();

    builder.Property(x => x.StudentId)
      .IsRequired();
  }
}
