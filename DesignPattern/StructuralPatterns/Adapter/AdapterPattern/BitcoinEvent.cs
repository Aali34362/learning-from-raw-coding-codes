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
        // Additional work related to BitcoinEvent can be done here.
        Console.WriteLine("Executing Bitcoin Event...");
        return userNF.NotifyUser("user1", "Bitcoin price increased!");
    }
}
