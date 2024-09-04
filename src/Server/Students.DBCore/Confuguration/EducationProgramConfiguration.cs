using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration
{
    internal class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgram>
    {
        public void Configure(EntityTypeBuilder<EducationProgram> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasMany(g => g.Groups)
                .WithOne(ep => ep.EducationProgram)
                .HasForeignKey(ep => ep.EducationProgramId);

            builder.HasOne(et => et.EducationType)
                .WithMany()
                .HasForeignKey(et => et.EducationTypeId);

            builder.HasOne(ef => ef.EducationForm)
                .WithMany()
                .HasForeignKey(ef => ef.EducationFormId);

            builder.HasOne(f => f.FEAProgram)
                .WithMany()
                .HasForeignKey(f => f.FEAProgramId);

            builder.HasOne(ft => ft.FinancingType)
                .WithMany()
                .HasForeignKey(ft => ft.FinancingTypeId);
        }
    }
}
