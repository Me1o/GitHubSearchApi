using System;
using System.Net.Http;
using System.Threading.Tasks;
using gitHubSearchApi.Services.Interfaces;
using gitHubSearchApi.Services.Types;

namespace gitHubSearchApi.Services
{
    public class SearchService: ISearchService
    {
        private readonly IHttpClientFactory _clientFactory;

        public SearchService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<SearchResultDto> search(string q, SearchType t, int p) {
            var url = "";
            if (t == SearchType.repos)
            {
              url = "https://api.github.com/search/repositories?q=" + q + "&per_page=10&page=" + p;
            }
            else {
              url = "https://api.github.com/search/users?q=" + q + "&per_page=10&page=" + p;
            }

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("hos4am");
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                SearchResultDto obj = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResultDto>(result);
                return obj;
            }
            else
            {
                return null;

            }
        }
    }
}
