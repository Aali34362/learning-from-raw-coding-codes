using Dumpify;

namespace Singleton.SingletonPattern;

public class MemoryCache
{
    private static MemoryCache _instance;
    private MemoryCache()
    {
        "Created".Dump();
    }
    public static MemoryCache Create() => _instance ?? (_instance = new MemoryCache());    
}
