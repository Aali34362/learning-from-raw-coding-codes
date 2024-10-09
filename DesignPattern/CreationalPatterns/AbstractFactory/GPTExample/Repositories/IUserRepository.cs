using AbstractFactory.GPTExample.Model;

namespace AbstractFactory.GPTExample.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    User GetUserById(int id);
    void DeleteUser(int id);
}
