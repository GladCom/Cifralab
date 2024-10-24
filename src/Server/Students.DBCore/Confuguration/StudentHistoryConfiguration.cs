using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Confuguration;

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

    builder.Property(x => x.Name);

    builder.Property(x => x.ChangeDate);
  }
}

