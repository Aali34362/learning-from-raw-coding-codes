namespace SemaphoreCode;

public static class SemaphoreSlimAsyncChatGPT
{
    static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2); // Initial count of 2
    static async Task AccessResourceAsync(int id)
    {
        Console.WriteLine($"Task {id} waiting to enter...");
        await semaphoreSlim.WaitAsync(); // Asynchronously wait to enter the semaphore

        Console.WriteLine($"Task {id} has entered.");
        await Task.Delay(1000); // Simulate some work asynchronously

        Console.WriteLine($"Task {id} is leaving.");
        semaphoreSlim.Release(); // Release the semaphore
    }
    public static async Task SemaphoreSlimAsyncMain()
    {
        Task[] tasks = new Task[5];

        for (int i = 1; i <= 5; i++)
        {
            int taskId = i;
            tasks[i - 1] = AccessResourceAsync(taskId);
        }

        await Task.WhenAll(tasks); // Wait for all tasks to complete
    }
}
