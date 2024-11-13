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

    builder.HasOne(r => r.Request)
      .WithMany(o => o.Orders)
      .HasForeignKey(r => r.RequestId);

    builder.HasOne(k => k.KindOrder)
      .WithMany()
      .HasForeignKey(k => k.KindOrderId);
  }
}