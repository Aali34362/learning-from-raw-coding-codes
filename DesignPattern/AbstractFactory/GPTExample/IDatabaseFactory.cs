namespace AbstractFactory.GPTExample;

public interface IDatabaseFactory
{
    ApplicationDbContext CreateDbContext();
    IUserRepository CreateUserRepository(ApplicationDbContext dbContext);
}
