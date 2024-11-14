using Microsoft.EntityFrameworkCore;
using Students.DBCore.Contexts;

namespace Students.DB.Converter.DBContext;

public sealed class PgContext : StudentContext
{
  private static readonly string DbServer = Settings.Default.DBServer;
  private static readonly string DbName = Settings.Default.DBName;
  private static readonly string DbPort = Settings.Default.DBPort;
  private static readonly string DbLogin = Settings.Default.DBLogin;
  private static readonly string DbPassword = Settings.Default.DBPassword;
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    optionsBuilder.UseNpgsql(
      $"Host={DbServer};Port={DbPort};Database={DbName};Username={DbLogin};Password={DbPassword};",
      o => o.CommandTimeout(60));
  }

  public PgContext()
  {
    this.Database.EnsureCreated();
  }
}