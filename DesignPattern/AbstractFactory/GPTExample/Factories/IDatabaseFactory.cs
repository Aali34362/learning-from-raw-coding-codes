using AbstractFactory.GPTExample.Contexts;
using AbstractFactory.GPTExample.Repositories;

namespace AbstractFactory.GPTExample.Factories;

public interface IDatabaseFactory
{
    ApplicationDbContext CreateDbContext();
    IUserRepository CreateUserRepository(ApplicationDbContext dbContext);
}
