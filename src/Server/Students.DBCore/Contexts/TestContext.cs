using Microsoft.EntityFrameworkCore;

namespace Students.DBCore.Contexts;
public class TestContext : StudentContext
{
  public TestContext()
  {
    this.Database.EnsureDeleted();
    this.Database.EnsureCreated();
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseInMemoryDatabase(databaseName: "ImMemoryTestDB");
  }
}
