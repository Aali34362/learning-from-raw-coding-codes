using Factory.FactoryPattern;
using Factory.geeksforgeeks.ProblemOriented;
using Factory.geeksforgeeks.SolutionOriented;
using Factory.GPTExample;
using Factory.RefactoringGuru;
using Microsoft.EntityFrameworkCore;

new NavigationBar();
new DropDownMenu();

new Client().Main();


ClientBuyer pClient = new ClientBuyer(1);
Vehicle pVehicle = pClient.getVehicle();
if (pVehicle != null)
{
    pVehicle.printVehicle();
}
pClient.cleanup();

/*
What are the problems with the above design? 
In the above code design:
Tight Coupling: The client class Client directly instantiates the concrete classes (TwoWheeler and FourWheeler) based on the input type provided during its construction. This leads to tight coupling between the client and the concrete classes, making the code difficult to maintain and extend.
Violation of Single Responsibility Principle (SRP): The Client class is responsible not only for determining which type of vehicle to instantiate based on the input type but also for managing the lifecycle of the vehicle object (e.g., cleanup). This violates the Single Responsibility Principle, which states that a class should have only one reason to change.
Limited Scalability: Adding a new type of vehicle requires modifying the Client class, which violates the Open-Closed Principle. This design is not scalable because it cannot accommodate new types of vehicles without modifying existing code.

How do we avoid the problem?
Define Factory Interface: Create a VehicleFactory interface or abstract class with a method for creating vehicles.
Implement Concrete Factories: Implement concrete factory classes (TwoWheelerFactory and FourWheelerFactory) that implement the VehicleFactory interface and provide methods to create instances of specific types of vehicles.
Refactor Client: Modify the Client class to accept a VehicleFactory instance instead of directly instantiating vehicles. The client will request a vehicle from the factory, eliminating the need for conditional logic based on vehicle types.
Enhanced Flexibility: With this approach, adding new types of vehicles is as simple as creating a new factory class for the new vehicle type without modifying existing client code.
 */

IVehicleFactory twoWheelerFactory = new TwoWheelerFactory();
ClientFP twoWheelerClient = new ClientFP(twoWheelerFactory);
VehicleFP twoWheeler = twoWheelerClient.getVehicle();
twoWheeler.printVehicle();

IVehicleFactory fourWheelerFactory = new FourWheelerFactory();
ClientFP fourWheelerClient = new ClientFP(fourWheelerFactory);
VehicleFP fourWheeler = fourWheelerClient.getVehicle();
fourWheeler.printVehicle();


//GPT

// Choose the desired database connection by selecting the factory
IDatabaseFactory factoryMySql = new MySqlConnectionFactory();
// Create the connection using the factory
IDatabaseConnection connectionMySql = factoryMySql.CreateConnection();
// Use the connection
connectionMySql.Connect();
connectionMySql.Disconnect();

IDatabaseFactory factorySqlServer = new SqlServerConnectionFactory();
IDatabaseConnection connectionSqlServer = factorySqlServer.CreateConnection();
connectionSqlServer.Connect();
connectionSqlServer.Disconnect();

IDatabaseFactory factoryMongoDb = new MongoDbConnectionFactory();
IDatabaseConnection connectionMongoDb = factoryMongoDb.CreateConnection();
connectionMongoDb.Connect();
connectionMongoDb.Disconnect();


// Use the appropriate factory based on your configuration or input.
IDatabaseFactoryPattern factory;

// For SQL Server
// Make sure to replace with your actual SQL Server connection string
factory = new SqlServerFactoryPattern("Server=localhost;Database=TestDB;User Id=sa;Password=your_password;");

// Create DbContext using the factory
using var dbContext = factory.CreateDbContext();

// Apply migrations and create the database if it doesn't exist
dbContext.Database.Migrate();

// Perform database operations
PerformDatabase.PerformDatabaseOperations(dbContext);

// Use the appropriate factory based on your configuration or input.
IDatabaseFactoryPattern mySqlFactory;
// For MySQL
// Uncomment this line and comment out the SqlServerFactory line to use MySQL instead.
// Make sure to replace with your actual MySQL connection string
mySqlFactory = new MySqlFactoryPattern("Server=localhost;Database=TestDB;User=root;Password=your_password;");

// Create DbContext using the factory
using var mySqlDbContext = mySqlFactory.CreateDbContext();

// Apply migrations and create the database if it doesn't exist
mySqlDbContext.Database.Migrate();

// Perform database operations
PerformDatabase.PerformDatabaseOperations(mySqlDbContext);