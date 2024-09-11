using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(r => r.Request)
                .WithMany(o => o.Orders)
                .HasForeignKey(r => r.RequestId);

            builder.HasOne(k => k.Kind)
                .WithMany()
                .HasForeignKey(k => k.KindOrderId);
        }
    }
}
