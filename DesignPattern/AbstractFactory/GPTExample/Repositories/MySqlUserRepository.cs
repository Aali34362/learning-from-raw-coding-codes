using AbstractFactory.GPTExample.Contexts;
using AbstractFactory.GPTExample.Model;

namespace AbstractFactory.GPTExample.Repositories;

internal class MySqlUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MySqlUserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public User GetUserById(int id)
    {
        return _dbContext.Users.Find(id);
    }

    public void DeleteUser(int id)
    {
        var user = _dbContext.Users.Find(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
