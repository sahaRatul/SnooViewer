using LibSnoo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibSnoo.Utils;
using System.Linq;

namespace LibSnoo
{
    public class Landing
    {
        private readonly HttpClient httpClient;
        public Landing()
        {
            httpClient = new HttpClient();
        }

        public Task<UserViewModel> GetUserDetails(string token)
        {
            return httpClient.GetAsync<UserViewModel>(Constants.Constants.redditOauthApiBaseUrl + "api/v1/me", LibSnoo.Models.DataContext.Token);
        }

        public async Task<List<SubredditViewModel>> GetSubscribedSubreddits(string token)
        {
            return (await httpClient.GetAsync<KindViewModel>(Constants.Constants.redditOauthApiBaseUrl + "subreddits/mine/subscriber?limit=100", token)).Data.Children.Select(x => x.Data).ToList();
        }
    }
}
