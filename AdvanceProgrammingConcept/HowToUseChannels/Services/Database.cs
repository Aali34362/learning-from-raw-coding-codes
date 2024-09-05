using HowToUseChannels.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace HowToUseChannels.Services;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}
