using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

internal class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgram>
{
  public void Configure(EntityTypeBuilder<EducationProgram> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.Cost)
      .IsRequired();

    builder.Property(x => x.HoursCount)
      .IsRequired();

    builder.Property(x => x.EducationFormId)
      .IsRequired();

    builder.Property(x => x.KindDocumentRiseQualificationId)
      .IsRequired();

    builder.Property(x => x.IsModularProgram)
      .IsRequired();

    builder.Property(x => x.FinancingTypeId)
      .IsRequired();

    builder.Property(x => x.IsCollegeProgram)
      .IsRequired();

    builder.Property(x => x.IsArchive)
      .IsRequired();

    builder.Property(x => x.IsNetworkProgram)
      .IsRequired();

    builder.Property(x => x.IsDOTProgram)
      .IsRequired();

    builder.Property(x => x.IsFullDOTProgram)
      .IsRequired();

    builder.HasOne(ep => ep.EducationForm)
      .WithMany()
      .HasForeignKey(ep => ep.EducationFormId);

    builder.HasOne(ep => ep.FEAProgram)
      .WithMany()
      .HasForeignKey(ep => ep.FEAProgramId);

    builder.HasOne(ep => ep.FinancingType)
      .WithMany()
      .HasForeignKey(ep => ep.FinancingTypeId);
  }
}