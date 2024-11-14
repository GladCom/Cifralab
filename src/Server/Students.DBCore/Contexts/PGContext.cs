using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Students.DBCore.Contexts;

public sealed class PgContext : StudentContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(
      $"Host={Environment.GetEnvironmentVariable("DBServer")};Port={Environment.GetEnvironmentVariable("DBPort")};Database={Environment.GetEnvironmentVariable("DBName")};Username={Environment.GetEnvironmentVariable("DBLogin")};Password={Environment.GetEnvironmentVariable("DBPassword")};",
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