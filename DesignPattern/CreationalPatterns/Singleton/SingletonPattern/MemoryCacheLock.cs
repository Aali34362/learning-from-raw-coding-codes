using Dumpify;

namespace Singleton.SingletonPattern;

public class MemoryCacheLock
{
    private static MemoryCacheLock _instance;
    private static int i = 0;
    private static object _cacheLock = new object();
    private MemoryCacheLock()
    {
        $"Created {i++}".Dump();
    }
    public static MemoryCacheLock Create()
    {
        if (_instance == null)
        {
            lock (_cacheLock)
            {
                return _instance = new MemoryCacheLock();
            }
        }
        return _instance;
    }
}
