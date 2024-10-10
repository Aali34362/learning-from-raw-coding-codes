namespace Adapter.AdapterPattern;

public class EmployeeFiredEvent
{
    private readonly IUserNotificationService userNF;
    public EmployeeFiredEvent(IUserNotificationService userNF)
    {
        this.userNF = userNF;
    }
    public Task Execute()
    {
        // Additional work related to EmployeeFiredEvent can be done here.
        Console.WriteLine("Executing Employee Fired Event...");
        return userNF.NotifyUser("user2", "You have been fired.");
    }
}
