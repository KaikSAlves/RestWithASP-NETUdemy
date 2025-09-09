using Microsoft.EntityFrameworkCore;

namespace RestWithASP_NETUdemy.Model.Context;

public class MySqlContext : DbContext
{
    public MySqlContext()
    {
        
    }

    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
            .Property(p => p.Enable)
            .HasConversion<bool>();
    }

    public DbSet<Person> Persons { get; set; }  
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    
}