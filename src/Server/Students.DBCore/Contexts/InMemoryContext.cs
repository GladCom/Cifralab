using Microsoft.EntityFrameworkCore;
using Students.Models;

namespace Students.DBCore.Contexts;

public sealed class InMemoryContext : StudentContext
{
    public InMemoryContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ImMemoryDB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EducationForm>().HasData(
            new EducationForm { Id = Guid.NewGuid(), Name = "Очная" },
            new EducationForm { Id = Guid.NewGuid(), Name = "Заочная" },
            new EducationForm { Id = Guid.NewGuid(), Name = "Очно-заочная" }
        );
    }
    
}