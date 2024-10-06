using AbstractFactory.GPTExample.Contexts;
using AbstractFactory.GPTExample.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.GPTExample.Factories;

public class SqlServerFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public SqlServerFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ApplicationDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(_connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }

    public IUserRepository CreateUserRepository(ApplicationDbContext dbContext)
    {
        return new SqlServerUserRepository(dbContext);
    }
}
