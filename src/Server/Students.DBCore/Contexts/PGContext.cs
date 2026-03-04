using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace Students.DBCore.Contexts;

public sealed class PgContext : WorkContext
{
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
             configurationBuilder.Properties<DateTime>()
            .HaveConversion<UtcValueConverter>();

             configurationBuilder.Properties<DateTime?>()
            .HaveConversion<UtcNullableValueConverter>();
    }

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
    }
}
public class UtcValueConverter : ValueConverter<DateTime, DateTime>
{
    public UtcValueConverter()
        : base(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}
public class UtcNullableValueConverter : ValueConverter<DateTime?, DateTime?>
{
    public UtcNullableValueConverter()
        : base(
            v => v.HasValue ? v.Value.ToUniversalTime() : v,
            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v)
    {
    }
}