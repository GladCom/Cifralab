using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Configuration;

internal class ScopeOfActivityConfiguration : IEntityTypeConfiguration<ScopeOfActivity>
{
  public void Configure(EntityTypeBuilder<ScopeOfActivity> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.NameOfScope);

    builder.Property(x => x.Level)
      .IsRequired();
  }
}