using Dumpify;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SemaphoreCode;

public static class HttpClientProgram
{
    static HttpClient _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(5) };
    static SemaphoreSlim _gate = new(1);
    //it protects a certain process asynchronously.
    public static void HttpClientProgramMain()
    {
        Task.WaitAll(CreateCalls().ToArray());
    }

    public static IEnumerable<Task> CreateCalls()
    {
        for(int i = 0; i< 200; i++)
        {
            yield return CallGoogle();
        }
    }

    public static async Task CallGoogle()
    {
        try
        {
            await _gate.WaitAsync();
            var response = await _client.GetAsync("https://google.com");
            _gate.Release();
            response.StatusCode.Dump();
        }
        catch(Exception e)
        {
            e.Message.Dump();
        }
    }
}
