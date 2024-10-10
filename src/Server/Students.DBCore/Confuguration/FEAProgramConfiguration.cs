using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration;

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