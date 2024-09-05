using HowToUseChannels.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace HowToUseChannels.Controllers;

[ApiController]
[Route("[controller]")]
public class ChannelController : Controller
{
    [HttpGet("Send")]
    public IActionResult Send()
    {
        Task.Run(() =>
        {
            Task.Delay(100).Wait();

            Task.Delay(200).Wait();
        });
        return Ok();
    }
    [HttpGet("SendA")]
    public bool SendA([FromServices] Notifications notifications)
    {
        return notifications.SendA();
    }
    [HttpGet("SendB")]
    public Task<bool> SendB([FromServices] Notifications notifications)
    {
        return notifications.Send();
    }    
    [HttpGet("SendC")]
    public async Task<bool> SendC([FromServices] Channel<string> channel)
    {
        await channel.Writer.WriteAsync("Hello World");
        return true;
    }
}
