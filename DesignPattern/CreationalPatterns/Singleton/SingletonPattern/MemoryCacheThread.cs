using Dumpify;

namespace Singleton.SingletonPattern;

public class MemoryCacheThread
{
    private static MemoryCacheThread _instance;
    private static int i = 0;
    private MemoryCacheThread()
    {
        $"Created {i++}".Dump();
    }
    public static MemoryCacheThread Create() => _instance ?? (_instance = new MemoryCacheThread());
}
