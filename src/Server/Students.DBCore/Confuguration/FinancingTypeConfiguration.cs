using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration;

internal class FinancingTypeConfiguration : IEntityTypeConfiguration<FinancingType>
{
  public void Configure(EntityTypeBuilder<FinancingType> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();
  }
}