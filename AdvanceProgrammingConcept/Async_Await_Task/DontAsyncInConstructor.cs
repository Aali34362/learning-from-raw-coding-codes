using Microsoft.AspNetCore.Mvc;

namespace Async_Await_Task;

public static class DontAsyncInConstructor
{
    public static async Task<ActionResult> Index()
    {
        var myClassInstance = await MyClass.CreateAsync();
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

public class SomeObject
{
    public SomeObject()
    {
        // never do asyn here
    }
    public async Task<SomeObject> Create()
    {
        return new SomeObject();
    }
}

public class SomeObjectFactory
{
    public SomeObjectFactory()
    {
        
    }
    public async Task<SomeObject> Create()
    {
        return new SomeObject();
    }
}

public class MyClass
{
    private MyClass()
    {
        // Constructor is private to enforce async initialization via factory
    }

    // Factory method to initialize asynchronously
    public static async Task<MyClass> CreateAsync()
    {
        var instance = new MyClass();
        await instance.InitializeAsync();
        return instance;
    }

    // Async initialization method
    private async Task InitializeAsync()
    {
        // Perform async operations here
        await Task.Delay(1000); // Simulating async work
    }
}