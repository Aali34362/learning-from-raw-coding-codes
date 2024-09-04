using Microsoft.AspNetCore.Mvc;

namespace Async_Await_Task;

public static class DoesntMatterWhichThread
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
        var content = await client.GetStringAsync("https://google.com").ConfigureAwait(false);
        // do something with the content
        return content;
    }
}
