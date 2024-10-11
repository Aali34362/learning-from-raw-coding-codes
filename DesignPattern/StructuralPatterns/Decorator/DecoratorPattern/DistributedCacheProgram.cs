using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Decorator.DecoratorPattern;

public static class DistributedCacheProgram
{
    public static void DistributedCacheMain()
    {
        // Setup the DI container with a distributed memory cache (for demo purposes)
        var services = new ServiceCollection();
        services.AddDistributedMemoryCache();

        var serviceProvider = services.BuildServiceProvider();

        // Get the distributed cache from the service provider
        var cache = serviceProvider.GetRequiredService<IDistributedCache>();

        // Wrap the cache with the KeyPrefixedCache decorator
        var prefixedCache = new KeyPrefixedCache(cache, "user");

        // Simulate setting and getting cache values
        string cacheKey = "123";
        byte[] valueToCache = System.Text.Encoding.UTF8.GetBytes("cached_value");

        // Set a value in the cache
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) // Cache expires after 5 minutes
        };

        prefixedCache.Set(cacheKey, valueToCache, cacheOptions);
        Console.WriteLine($"Set cache value for key: {cacheKey}");

        // Retrieve the cached value
        byte[] cachedValue = prefixedCache.Get(cacheKey);
        if (cachedValue != null)
        {
            string cachedValueString = System.Text.Encoding.UTF8.GetString(cachedValue);
            Console.WriteLine($"Retrieved cached value: {cachedValueString}");
        }
        else
        {
            Console.WriteLine("Cache miss. Value not found.");
        }

        // Remove the cached value
        prefixedCache.Remove(cacheKey);
        Console.WriteLine($"Removed cache value for key: {cacheKey}");

        // Try to retrieve the cached value after removal
        cachedValue = prefixedCache.Get(cacheKey);
        if (cachedValue == null)
        {
            Console.WriteLine("Value successfully removed from cache.");
        }
    }
}

public class KeyPrefixedCache : IDistributedCache
{
    IDistributedCache _cache;
    string _prefix;

    public KeyPrefixedCache(IDistributedCache cache, string prefix)
    {
        _cache = cache;
        _prefix = prefix;
    }

    private string PrefixKey(string key) => $"{_prefix}_{key}";

    public byte[] Get(string key) =>
        _cache.Get(PrefixKey(key));

    public Task<byte[]> GetAsync(string key, CancellationToken token = default) =>
        _cache.GetAsync(PrefixKey(key), token);

    public void Refresh(string key) =>
        _cache.Refresh(PrefixKey(key));

    public Task RefreshAsync(string key, CancellationToken token = default) =>
        _cache.RefreshAsync(PrefixKey(key), token);

    public void Remove(string key) =>
        _cache.Remove(PrefixKey(key));

    public Task RemoveAsync(string key, CancellationToken token = default) =>
        _cache.RemoveAsync(PrefixKey(key), token);

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options) =>
        _cache.Set(PrefixKey(key), value, options);

    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default) =>
        _cache.SetAsync(PrefixKey(key), value, options, token);
}
