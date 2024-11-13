using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

internal class DocumentRiseQualificationConfiguration : IEntityTypeConfiguration<DocumentRiseQualification>
{
  public void Configure(EntityTypeBuilder<DocumentRiseQualification> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.KindDocumentRiseQualificationId)
      .IsRequired();

    builder.Property(x => x.Date)
      .IsRequired();

    builder.Property(x => x.Number)
      .IsRequired();

    builder.HasOne(k => k.KindDocumentRiseQualification)
      .WithMany()
      .HasForeignKey(k => k.KindDocumentRiseQualificationId);

    builder.Property(x => x.Date);
    builder.Property(x => x.Number);
  }
}