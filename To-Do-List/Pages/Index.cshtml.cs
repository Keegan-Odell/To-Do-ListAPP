using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "CounterKey";
    public int Counter { get; set; }

    public IndexModel(IMemoryCache cache, ILogger<IndexModel> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public void OnGet()
    {
        Counter = _cache.GetOrCreate(CacheKey, entry => 0);
    }

    public void OnPostUp()
    {
        Counter = _cache.GetOrCreate(CacheKey, entry => 0);

        Counter++;

        _cache.Set(CacheKey, Counter);
    }

    public void OnPostDown()
    {
        Counter = _cache.GetOrCreate(CacheKey, entry => 0) - 1;

        _cache.Set(CacheKey, Counter);
    }
}