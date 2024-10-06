using AbstractFactory.Model;

namespace AbstractFactory.GPTExample;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    User GetUserById(int id);
    void DeleteUser(int id);
}
