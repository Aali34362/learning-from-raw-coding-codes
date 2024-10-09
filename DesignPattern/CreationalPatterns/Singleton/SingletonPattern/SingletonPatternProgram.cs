using Dumpify;

namespace Singleton.SingletonPattern;

public static class SingletonPatternProgram
{
    public static void SingletonPatternMain()
    {
        MemoryCache.Create();
        MemoryCache.Create();
        MemoryCache.Create();
        MemoryCache.Create();

        //Thread on Singleton Pattern

        int size = 8;
        Task[] tasks = new Task[size];
        for(int i = 0; i < size; i++)
        {
            tasks[i] = Task.Run(() => MemoryCacheThread.Create());
        }
        Task.WaitAll(tasks);

        //Lock
        int sizeLock = 8;
        Task[] tasksLock = new Task[sizeLock];
        for (int i = 0; i < sizeLock; i++)
        {
            tasksLock[i] = Task.Run(() => MemoryCacheLock.Create());
        }
        Task.WaitAll(tasksLock);

        //
        int sizeSyncAccess = 10;
        Task[] tasksSyncAccess = new Task[sizeSyncAccess];
        for (int i = 0; i < size; i++)
        {
            tasksSyncAccess[i] = Task.Run(() =>
            {
                var c = MemoryCacheSyncAccess.Create();
                if (c.AquireKey("job_id", "job1"))
                {
                    "Big Operation".Dump();
                }
            });
        }
        Task.WaitAll(tasksSyncAccess);
    }
}
