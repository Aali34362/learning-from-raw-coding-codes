namespace Async_Await_Task;

public static class WhereDoesItStart
{
    public static void WhereDoesItStartMain()
    {
        StartApp1();
        StartApp2().GetAwaiter().GetResult();
    }
    public static Task StartApp2()
    {
        var collect = Collect();
        var process = Process("Hello world");
        return Task.WhenAll(new[] { collect, process });
    }
    public static void StartApp1()
    {
        var collect = Collect();
        var process = Process("Hello world");
        Task.WaitAll(new[] { collect, process } );
    }
    public static async Task Collect()
    {
        while (true)
        {
            // doing some internet stuff
        }
    }
    public static async Task Process(string message)
    {
        while (true)
        {
            // doing some database stuff
            if (true)
            {
                //Fire and Forget
                Task.Run(() => Notify("Hi"));
            }
        }
    }
    public static async Task Notify(string data)
    {
        // some network stuff
    }
}
