using AbstractFactory.Model;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.GPTExample;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
