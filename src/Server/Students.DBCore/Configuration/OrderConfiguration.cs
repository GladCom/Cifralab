using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Configuration;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .IsRequired()
      .ValueGeneratedOnAdd();

    builder.Property(x => x.Date)
      .IsRequired();

    builder.Property(x => x.KindOrderId)
      .IsRequired();

    builder.Property(x => x.RequestId)
      .IsRequired();

    builder.HasOne(o => o.Request)
      .WithMany(r => r.Orders)
      .HasForeignKey(o => o.RequestId);

    builder.HasOne(o => o.KindOrder)
      .WithMany()
      .HasForeignKey(o => o.KindOrderId);
  }
}