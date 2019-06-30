using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibSnoo.Models;
using LibSnoo.Utils;

namespace LibSnoo
{
    public class SubredditPostList
    {
        private readonly HttpClient httpClient;
        public SubredditPostList()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<PostOrSubRedditDataViewModel>> GetSubredditPosts(string subreddit = "all", string getByCriteria = "hot", int limit = 10, string token = null)
        {
            var url = Constants.Constants.redditOauthApiBaseUrl + "r/" + subreddit + "/" + getByCriteria + "?limit=" + limit.ToString();
            return (await httpClient.GetAsync<KindViewModel>(url, token)).Data.Children.Select(x => x.Data).ToList();
        }
    }
}
