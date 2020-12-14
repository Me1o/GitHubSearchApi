using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gitHubSearchApi.Services.Interfaces;
using gitHubSearchApi.Services.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace gitHubSearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private IMemoryCache _cache;
        public SearchController(ISearchService searchService, IMemoryCache memoryCache)
        {
            _searchService = searchService;
            _cache = memoryCache;

        }

        // GET api/search/search
        [HttpGet("{t}/{q}/{p}")]
        public SearchResultDto search(string q, SearchType t, int p)
        {
            var key = t + "-" + q + "pg" + p;
            var cacheEntry = _cache.Get<SearchResultDto>(key);
            if (cacheEntry != null)
            {
                return cacheEntry;
            }
            else {
                var val = _searchService.search(q, t, p);
                _cache.Set<SearchResultDto>(key, val.Result, new DateTimeOffset().AddMinutes(60));
                return val.Result;
            }
        }

        // POST api/clear-cache
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
