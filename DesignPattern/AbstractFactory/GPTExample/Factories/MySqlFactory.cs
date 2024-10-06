using AbstractFactory.GPTExample.Contexts;
using AbstractFactory.GPTExample.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.GPTExample.Factories;

public class MySqlFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public MySqlFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ApplicationDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        return new ApplicationDbContext(optionsBuilder.Options);
    }

    public IUserRepository CreateUserRepository(ApplicationDbContext dbContext)
    {
        return new MySqlUserRepository(dbContext);
    }
}
