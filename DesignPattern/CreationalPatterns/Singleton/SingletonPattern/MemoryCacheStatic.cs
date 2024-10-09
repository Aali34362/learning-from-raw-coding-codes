using Dumpify;

namespace Singleton.SingletonPattern;

internal class MemoryCacheStatic
{
    private static MemoryCacheStatic _instance;
    private static int i = 0;

    static MemoryCacheStatic()
    {
        _instance = new MemoryCacheStatic();
    }
    private MemoryCacheStatic()
    {
        $"Created {i++}".Dump();
    }
    public static MemoryCacheStatic Create() => _instance;
}
