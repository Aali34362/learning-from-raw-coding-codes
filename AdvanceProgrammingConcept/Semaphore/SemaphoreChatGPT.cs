﻿namespace SemaphoreCode;

public static class SemaphoreChatGPT
{
    static Semaphore semaphore = new(3, 3); // Initialize a semaphore with a maximum count of 3
    public static void SemaphoreChatGPTMain()
    {
        for (int i = 1; i <= 5; i++)
        {
            int threadId = i;
            new Thread(() => AccessResource(threadId)).Start();
        }
    }
    static void AccessResource(int id)
    {
        Console.WriteLine($"Thread {id} waiting to enter...");
        semaphore.WaitOne(); // Decrease the count and enter critical section

        Console.WriteLine($"Thread {id} has entered.");
        Thread.Sleep(1000); // Simulate work

        Console.WriteLine($"Thread {id} is leaving.");
        semaphore.Release(); // Increase the count and leave critical section
    }
}
