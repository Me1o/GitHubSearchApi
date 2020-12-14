using System;
namespace gitHubSearchApi.Services.Types
{
    public class RepoOwner
    {
        public String id { get; set; }
        public String login { get; set; }
        public String avatar_url { get; set; }
        public String url { get; set; }
        public string public_repos { get; set; }
        public string followers { get; set; }
        public string following { get; set; }
    }
}

