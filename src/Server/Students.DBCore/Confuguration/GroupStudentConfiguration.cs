using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Models;

namespace Students.DBCore.Confuguration
{
  /// <summary>
  /// Конфигурация сущности ГруппаСтуденты
  /// </summary>
  internal class GroupStudentConfiguration : IEntityTypeConfiguration<GroupStudent>
  {
    public void Configure(EntityTypeBuilder<GroupStudent> builder)
    {
      builder.HasKey(gs => new { gs.StudentsId, gs.GroupsId});

      builder.HasOne(g => g.Group)
        .WithMany(gs => gs.GroupStudent)
        .HasForeignKey(g => g.GroupsId);

      builder.HasOne(s => s.Student)
        .WithMany(gs => gs.GroupStudent)
        .HasForeignKey(s => s.StudentsId);
    }
  }
}
