namespace Factory.GPTExample;

public interface IDatabaseFactoryPattern
{
    ApplicationDbContext CreateDbContext();
}
