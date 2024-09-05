using Dumpify;
using System.Collections.Concurrent;

namespace Channels;

public static class VideoProcessingProblemProgram
{
    public static void VideoProcessingProblemProgramMain()
    {
        var channel = new Channel<string>();
        Task.WaitAll(Consumer(channel), Producer(channel));
    }

    private static Task Producer(IWrite<string> writer)
    {
        for (int i = 0; i < 100; i++)
        {
            $"Pushing {i}".Dump();
            writer.Push(i.ToString());
            Task.Delay(100).GetAwaiter().GetResult();
        }
        writer.Complete();
        return Task.CompletedTask;
    }
    private static async Task Consumer(IRead<string> reader)
    {
        while(!reader.IsComplete())
        {
            var msg = await reader.Read();
            msg.Dump("msg");
        }
    }

}


public interface IRead<T>
{
    Task<T> Read();
    bool IsComplete();
}

public interface IWrite<T>
{
    void Push(T msg);
    void Complete();
}

public class Channel<T> : IRead<T>, IWrite<T>
{
    private bool Finished;
    private ConcurrentQueue<T> _queue;
    private SemaphoreSlim _flag;
    public Channel()
    {
        _queue = new ConcurrentQueue<T>();
        _flag = new SemaphoreSlim(0);
    }
    public void Push(T msg)
    {
        _queue.Enqueue(msg);
        _flag.Release();
    }
    public async Task<T> Read()
    {
        await _flag.WaitAsync();
        if (_queue.TryDequeue(out var msg))
            return msg;
        return default!;
    }
    public void Complete()
    {
        Finished = true;
    }
    public bool IsComplete()
    {
        return Finished && _queue.IsEmpty;
    }
}