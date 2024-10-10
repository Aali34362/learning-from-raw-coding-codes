using SendGrid;

namespace Adapter.AdapterPattern;

public static class AdapterPatternProgram
{
    public static void AdapterPatternMain()
    {
        // SendGrid client options (just placeholder values)
        var sendGridOptions = new SendGridClientOptions
        {
            ApiKey = "your-api-key"
        };

        // Using Class Adapter
        IUserNotificationService classAdapter = new ClassAdapter(sendGridOptions);
        BitcoinEvent bitcoinEvent = new BitcoinEvent(classAdapter);
        bitcoinEvent.Execute();

        // Using Object Adapter
        SendGridClient sendGridClient = new SendGridClient(sendGridOptions);
        IUserNotificationService objectAdapter = new ObjectAdapter(sendGridClient);
        EmployeeFiredEvent employeeFiredEvent = new EmployeeFiredEvent(objectAdapter);
        employeeFiredEvent.Execute();
    }
}
