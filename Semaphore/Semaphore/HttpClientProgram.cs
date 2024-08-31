using Dumpify;

namespace SemaphoreCode;

public static class HttpClientProgram
{
    static HttpClient _client = new HttpClient();
    static SemaphoreSlim _gate = new(1);
    public static void HttpClientProgramMain()
    {
        CreateCalls();
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
        var response = await _client.GetAsync("https://google.com");
        response.StatusCode.Dump();
    }
}
