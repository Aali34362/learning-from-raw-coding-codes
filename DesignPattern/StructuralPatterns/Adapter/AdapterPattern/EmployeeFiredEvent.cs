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
        // other work here
        return userNF.NotifyUser("", "");
    }
}
