using Microsoft.EntityFrameworkCore;

namespace Factory.GPTExample;

internal class SqlServerFactoryPattern : IDatabaseFactoryPattern
{
    private readonly string _connectionString;

    public SqlServerFactoryPattern(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ApplicationDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(_connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
