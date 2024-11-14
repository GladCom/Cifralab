using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Configuration;

public class KindEducationProgramConfiguration : IEntityTypeConfiguration<KindEducationProgram>
{
  public void Configure(EntityTypeBuilder<KindEducationProgram> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name)
       .IsRequired();

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();
  }
}

