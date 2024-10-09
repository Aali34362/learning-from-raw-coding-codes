using Factory.Model;
using Microsoft.EntityFrameworkCore;

namespace Factory.GPTExample;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuration logic can go here, if needed.
    }
}
