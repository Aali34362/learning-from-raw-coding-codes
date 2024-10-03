namespace Factory.GPTExample;

internal class Connection
{
}

public interface IDatabaseConnection
{
    void Connect();
    void Disconnect();
}

public class MySqlConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connecting to MySQL Database...");
        // Actual connection logic goes here
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from MySQL Database...");
    }
}

public class SqlServerConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connecting to SQL Server Database...");
        // Actual connection logic goes here
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from SQL Server Database...");
    }
}

public class MongoDbConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connecting to MongoDB Database...");
        // Actual connection logic goes here
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from MongoDB Database...");
    }
}

// You can create more classes like PostgreSQLConnection, OracleConnection, etc.
