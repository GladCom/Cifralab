using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models.ReferenceModels;

namespace Students.DBCore.Configuration;

internal class TypeEducationConfiguration : IEntityTypeConfiguration<TypeEducation>
{
  public void Configure(EntityTypeBuilder<TypeEducation> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.Name)
      .IsRequired();
  }
}