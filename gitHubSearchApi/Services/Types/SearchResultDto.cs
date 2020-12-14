using System;
using System.Collections.Generic;

namespace gitHubSearchApi.Services.Types
{
    public class SearchResultDto
    {
        public string total_count { get; set; }
        public int page { get; set; }
        public List<Item> items { get; set; }

    }
}
