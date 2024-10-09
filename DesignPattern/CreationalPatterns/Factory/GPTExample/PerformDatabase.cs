using Factory.Model;

namespace Factory.GPTExample;

public static class PerformDatabase
{
    public static void PerformDatabaseOperations(ApplicationDbContext dbContext)
    {
        // Add a new user
        var user = new User
        {
            Name = "John Doe",
            Email = "johndoe@example.com"
        };
        dbContext.Users.Add(user);
        dbContext.SaveChanges();

        // Retrieve and display all users
        var users = dbContext.Users.ToList();
        Console.WriteLine("List of Users:");
        foreach (var u in users)
        {
            Console.WriteLine($"Id: {u.Id}, Name: {u.Name}, Email: {u.Email}");
        }

        // Update the user's email
        user.Email = "john.doe@example.com";
        dbContext.Users.Update(user);
        dbContext.SaveChanges();

        // Delete the user
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
    }
}
