namespace Factory.GPTExample;

internal class Factories
{
}

public interface IDatabaseFactory
{
    IDatabaseConnection CreateConnection();
}

public class MySqlConnectionFactory : IDatabaseFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new MySqlConnection();
    }
}

public class SqlServerConnectionFactory : IDatabaseFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new SqlServerConnection();
    }
}

public class MongoDbConnectionFactory : IDatabaseFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new MongoDbConnection();
    }
}

// Additional factories for other databases can be created similarly.