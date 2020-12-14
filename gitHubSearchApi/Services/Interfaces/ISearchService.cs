using System;
using System.Threading.Tasks;
using gitHubSearchApi.Services.Types;

namespace gitHubSearchApi.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResultDto> search(string q, SearchType t, int p);
    }
}
