using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Configuration;

internal class FEAProgramConfiguration : IEntityTypeConfiguration<FEAProgram>
{
  public void Configure(EntityTypeBuilder<FEAProgram> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();
  }
}