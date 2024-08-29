using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration
{
  /// <summary>
  /// Конфигурация сущности группы.
  /// </summary>
  internal class GroupConfiguration : IEntityTypeConfiguration<Group>
  {
    public void Configure(EntityTypeBuilder<Group> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();

      builder.HasMany(gs => gs.GroupStudent)
        .WithOne(g => g.Group);
    }
  }
}
