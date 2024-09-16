using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DBCore.Confuguration
{
    internal class ScopeOfActivityConfiguration : IEntityTypeConfiguration<ScopeOfActivity>
    {
        public void Configure(EntityTypeBuilder<ScopeOfActivity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NameOfScope);
            builder.Property(x => x.Level);  
        }
    }
}
