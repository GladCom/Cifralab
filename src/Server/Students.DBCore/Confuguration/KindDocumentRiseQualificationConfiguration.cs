using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration;

internal class KindDocumentRiseQualificationConfiguration : IEntityTypeConfiguration<KindDocumentRiseQualification>
{
  public void Configure(EntityTypeBuilder<KindDocumentRiseQualification> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.Name)
      .IsRequired();
  }
}