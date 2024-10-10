namespace Adapter.AdapterPattern;

public class BitcoinEvent
{
    private readonly IUserNotificationService userNF;

    public BitcoinEvent(IUserNotificationService userNF)
    {
        this.userNF = userNF;
    }

    public Task Execute()
    {
        // other work here
        return userNF.NotifyUser("", "");
    }
}
