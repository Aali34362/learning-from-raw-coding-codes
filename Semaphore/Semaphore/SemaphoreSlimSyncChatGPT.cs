namespace SemaphoreCode;

public static class SemaphoreSlimSyncChatGPT
{
    static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3); // Initial count of 3
    static void AccessResource(int id)
    {
        Console.WriteLine($"Thread {id} waiting to enter...");
        semaphoreSlim.Wait(); // Wait to enter the semaphore

        Console.WriteLine($"Thread {id} has entered.");
        Thread.Sleep(1000); // Simulate some work

        Console.WriteLine($"Thread {id} is leaving.");
        semaphoreSlim.Release(); // Release the semaphore
    }
    public static void SemaphoreSlimSyncMain()
    {
        for (int i = 1; i <= 5; i++)
        {
            int threadId = i;
            new Thread(() => AccessResource(threadId)).Start();
        }
    }
}
