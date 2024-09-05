using HowToUseChannels.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace HowToUseChannels.Controllers;

[ApiController]
[Route("[controller]")]
public class ChannelController : Controller
{
    public IActionResult Send()
    {
        Task.Run(() =>
        {
            Task.Delay(100).Wait();

            Task.Delay(200).Wait();
        });
        return Ok();
    }
    public Task<bool> SendB([FromServices] Notifications notifications)
    {
        return notifications.Send();
    }
    public bool SendA([FromServices] Notifications notifications)
    {
        return notifications.SendA();
    }
    public async Task<bool> SendC([FromServices] Channel<string> channel)
    {
        await channel.Writer.WriteAsync("Hello World");
        return true;
    }
}
