using Dumpify;
using Microsoft.EntityFrameworkCore;

namespace HowToUseChannels.Services;

public class Notifications(Database database, IHttpClientFactory httpClientFactory)
{
    private readonly Database database = database;
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

    public async Task<bool> Send()
    {
        if(!await database.Users.AnyAsync())
        {
            database.Users.Add(new Data.User());
            await database.SaveChangesAsync();
        }
        var user = await database.Users.FirstOrDefaultAsync();
        var client = httpClientFactory.CreateClient();
        var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
        user!.Message = response;
        await database.SaveChangesAsync();
        return true;
    }
    public bool SendA()
    {
        //Fire and Forget
        Task.Run(async () =>
        {
            try
            {
                if (!await database.Users.AnyAsync())
                {
                    database.Users.Add(new Data.User());
                    await database.SaveChangesAsync();
                }
                var user = await database.Users.FirstOrDefaultAsync();
                var client = httpClientFactory.CreateClient();
                var response = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/core/");
                user!.Message = response;
                await database.SaveChangesAsync();
            }
            catch (Exception ex) { ex.Dump(); }
        });
        return true;
    }
}
