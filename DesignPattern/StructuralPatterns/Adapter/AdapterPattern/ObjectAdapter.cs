using SendGrid;
using SendGrid.Helpers.Mail;

namespace Adapter.AdapterPattern;

public class ObjectAdapter : IUserNotificationService
{
    private readonly SendGridClient client;

    public ObjectAdapter(SendGridClient client)
    {
        this.client = client;
    }
    public Task NotifyUser(string userId, string message)
    {
        return client.SendEmailAsync(new SendGridMessage());
    }
}
