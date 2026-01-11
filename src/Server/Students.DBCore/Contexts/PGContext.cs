using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Students.DBCore.Contexts;

public sealed class PgContext : WorkContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      optionsBuilder.UseNpgsql(
          $"Host=localhost;Port=5432;Database=Cifralabs_local;Username=postgres;Password=123;",
          o => o.CommandTimeout(60));
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
#endif
  }

  public PgContext()
  {
    //this.Database.EnsureDeleted();
    this.Database.EnsureCreated();
  }
}