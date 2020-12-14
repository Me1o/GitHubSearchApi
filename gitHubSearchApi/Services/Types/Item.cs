using System;
namespace gitHubSearchApi.Services.Types
{
    public class Item
    {
        public string id { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string fork { get; set; }

        public string login { get; set; }
        public string avatar_url { get; set; }
        public string score { get; set; }

        public string public_repos { get; set; }
        public string followers { get; set; }
        public string following { get; set; }

        public RepoOwner owner { get; set; }
    }
}

