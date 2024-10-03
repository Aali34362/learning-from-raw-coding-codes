using Microsoft.EntityFrameworkCore;

namespace Factory.GPTExample;

public class MySqlFactoryPattern : IDatabaseFactoryPattern
{
    private readonly string _connectionString;

    public MySqlFactoryPattern(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ApplicationDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
