using Microsoft.EntityFrameworkCore;
using Person.Model;

namespace Person.Data;

public class PersonContext : DbContext
{
    public DbSet<Model.Person> People { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Person.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}