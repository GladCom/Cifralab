using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Students.Models;

namespace Students.DBCore.Confuguration
{
    internal class StudentStatusConfiguration : IEntityTypeConfiguration<StudentStatus>
    {
        public void Configure(EntityTypeBuilder<StudentStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Name);
        }
    }
}
