using Microsoft.EntityFrameworkCore;

namespace Students.DBCore.Contexts;

public sealed class InMemoryContext : WorkContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseInMemoryDatabase(databaseName: "ImMemoryDB");
  }

  public InMemoryContext()
  {
    this.Database.EnsureCreated();
  }
}
