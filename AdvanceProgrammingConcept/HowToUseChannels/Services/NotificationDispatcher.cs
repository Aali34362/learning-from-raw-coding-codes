using Dumpify;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace HowToUseChannels.Services;

public class NotificationDispatcher(
        Channel<string> channel,
        ILogger<NotificationDispatcher> logger,
        IHttpClientFactory httpClientFactory,
        IServiceProvider provider) : BackgroundService
{
    private readonly Channel<string> channel = channel;
    private readonly ILogger<NotificationDispatcher> logger = logger;
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;
    private readonly IServiceProvider provider = provider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!channel.Reader.Completion.IsCompleted)
        {
            // read from channel
            var msg = await channel.Reader.ReadAsync();
            msg.Dump("Read from channel");
            try
            {
                using (var scope = provider.CreateScope()) 
                {
                    var database = scope.ServiceProvider.GetRequiredService<Database>();
                    if(!await database.Users.AnyAsync())
                    {
                        database.Users.Add(new Data.User());
                        await database.SaveChangesAsync();
                    }
                    var user = await database.Users.FirstOrDefaultAsync();
                    user!.Dump("Read from In Memory");
                    var client = httpClientFactory.CreateClient();
                    var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
                    user!.Message = response;
                    user!.Dump("Read from In Memory");
                    await database.SaveChangesAsync();
                }
            }
            catch (Exception ex) { logger.LogError(ex, "notification failed"); }
        }
    }
}
