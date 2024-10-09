using AbstractFactory.AbstractFactoryPattern;
using AbstractFactory.geeksforgeeks;
using AbstractFactory.GPTExample.Contexts;
using AbstractFactory.GPTExample.Factories;
using AbstractFactory.GPTExample.Model;
using AbstractFactory.GPTExample.Repositories;
using AbstractFactory.RefactoringGuru;


new NavigationBar(new Apple());
new DropDownMenu(new Apple());

new NavigationBarFactoryMethod();
new AndroidNavigationBar();
new DropDownMenuFactoryMethod();
new AndroidDropDownMenu();

CarFactoryClient.CarFactoryClientMain();

ClientAbstractFactoryProgram.ClientProgramMain();




// Choose the factory based on configuration or input
IDatabaseFactory factory;

// Use SQL Server Factory
factory = new SqlServerFactory("Server=localhost;Database=TestDB;User Id=sa;Password=your_password;");

// Use MySQL Factory (Uncomment to use MySQL)
// factory = new MySqlFactory("Server=localhost;Database=TestDB;User=root;Password=your_password;");

// Create DbContext and Repository
ApplicationDbContext dbContext = factory.CreateDbContext();
IUserRepository userRepository = factory.CreateUserRepository(dbContext);

// Perform operations using repository
userRepository.AddUser(new User { Name = "Alice", Email = "alice@example.com" });
var users = userRepository.GetAllUsers();

Console.WriteLine("List of Users:");
foreach (var user in users)
{
    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}");
}