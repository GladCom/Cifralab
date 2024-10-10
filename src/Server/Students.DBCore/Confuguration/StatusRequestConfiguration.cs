using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration;

internal class StatusRequestConfiguration : IEntityTypeConfiguration<StatusRequest>
{
  public void Configure(EntityTypeBuilder<StatusRequest> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();
  }
}