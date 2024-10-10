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
        // Placeholder logic to create and send an email using SendGrid
        Console.WriteLine($"ClassAdapter: Notifying user {userId} with message: {message}");
        var msg = new SendGridMessage
        {
            From = new EmailAddress("noreply@domain.com", "Notifier"),
            Subject = "Notification",
            PlainTextContent = message,
            HtmlContent = $"<strong>{message}</strong>"
        };
        msg.AddTo(new EmailAddress($"{userId}@domain.com"));
        return SendEmailAsync(msg);
    }
}
