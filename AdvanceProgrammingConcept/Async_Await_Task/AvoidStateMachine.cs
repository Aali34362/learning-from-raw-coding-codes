using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Async_Await_Task;

public static class AvoidStateMachine
{
    public static async Task<ActionResult> Index()
    {
        var a = await InputOutputN();
        return View(a);
    }

    private static ActionResult View(string a)
    {
        throw new NotImplementedException();
    }

    public static async Task<string> InputOutputN()
    {
        var client = new HttpClient();
        var content = await client.GetStringAsync("https://google.com");
        // do something with the content
        return content;
    }

    public static Task<string> InputOutputNA()
    {
        var client = new HttpClient();
        return client.GetStringAsync("https://google.com");
    }

    public static Task<string> InputOutput()
    {
        var message = "Hello World";
        return Task.FromResult(message);
    }

    public static Task InputOutputC()
    {
        return Task.CompletedTask;
    }
}
