using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration
{
    internal class EducationTypeConfiguration : IEntityTypeConfiguration<EducationType>
    {
        public void Configure(EntityTypeBuilder<EducationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
