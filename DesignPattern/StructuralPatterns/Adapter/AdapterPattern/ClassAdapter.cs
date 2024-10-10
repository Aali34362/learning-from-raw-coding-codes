using SendGrid;
using SendGrid.Helpers.Mail;

namespace Adapter.AdapterPattern;

public class ClassAdapter : SendGridClient, IUserNotificationService
{
    public ClassAdapter(SendGridClientOptions options) : base(options)
    {
    }

    public Task NotifyUser(string userId, string message)
    {
        return SendEmailAsync(new SendGridMessage());
    }
}
