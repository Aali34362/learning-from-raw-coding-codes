namespace Adapter.AdapterPattern;

public interface IUserNotificationService
{
    Task NotifyUser(string userId, string message);
}
