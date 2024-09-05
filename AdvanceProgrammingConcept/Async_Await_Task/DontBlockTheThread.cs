using Microsoft.AspNetCore.Mvc;

namespace Async_Await_Task;

public static class DontBlockTheThread
{
    public static IActionResult Index()
    {
        var task = InputOutputN();
        //Bad
        var a = task.Result;
        //Bad
        task.Wait();
        //Bad
        task.GetAwaiter().GetResult();

        return View(); 
    }

    private static ActionResult View()
    {
        throw new NotImplementedException();
    }

    public static async Task<string> InputOutputN()
    {
        var client = new HttpClient();
        var content = await client.GetStringAsync("https://google.com").ConfigureAwait(false);
        // do something with the content
        return content;
    }
}
