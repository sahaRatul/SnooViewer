using LibSnoo.Models;
using LibSnoo.Utils;
using System.Threading.Tasks;

namespace LibSnoo
{
    public class ApiCalls
    {
        private readonly HttpClient httpClient;
        public ApiCalls()
        {
            httpClient = new HttpClient();
        }

        public Task<RulesViewModel> GetRulesForSubreddit(string token, string subreddit = "all")
        {
            return httpClient.GetAsync<RulesViewModel>(Constants.Constants.redditOauthApiBaseUrl + "r/" + subreddit + "/about/rules", token);
        }
    }
}
