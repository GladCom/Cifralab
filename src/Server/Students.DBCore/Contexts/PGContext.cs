using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Students.DBCore.Contexts;

public class PgContext : StudentContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            $"Host=212.60.20.223;Port=5432;Database=cifralabs_studentDB;Username=cifralabs_studentDB_Service;Password=P@ssw0rd!;",
            o => o.CommandTimeout(60));
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
#endif
    }
}