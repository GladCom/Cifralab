using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Confuguration;

internal class KindOrderConfiguration : IEntityTypeConfiguration<KindOrder>
{
  public void Configure(EntityTypeBuilder<KindOrder> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();
  }
}