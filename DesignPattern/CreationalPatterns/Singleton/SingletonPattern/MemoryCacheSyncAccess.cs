namespace Singleton.SingletonPattern;

public class MemoryCacheSyncAccess
{
    private static MemoryCacheSyncAccess cache;
    private static object cacheLock = new object();

    private readonly Dictionary<string, string> _registry;

    private MemoryCacheSyncAccess() => _registry = new Dictionary<string, string>();

    public static MemoryCacheSyncAccess Create()
    {
        if (cache == null)
        {
            lock (cacheLock)
            {
                if (cache == null)
                {
                    return cache = new MemoryCacheSyncAccess();
                }
            }
        }

        return cache;
    }

    public bool Contains(string key, string value)
    {
        return _registry.Contains(KeyValuePair.Create(key, value));
    }

    public void Write(string key, string value)
    {
        _registry[key] = value;
    }


    public bool AquireKey(string key, string value)
    {
        lock (cacheLock)
        {
            if (Contains("job_id", "job1"))
            {
                return false;
            }
            Write("job_id", "job1");

            return true;
        }
    }
}
