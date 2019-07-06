using LibSnoo.Models;
using LibSnoo.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibSnoo
{
    public class Landing
    {
        private readonly HttpClient httpClient;
        public Landing()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<MainDataViewModel>> GetSubscribedSubreddits(string token)
        {
            return (await httpClient.GetAsync<KindViewModel>(Constants.Constants.redditOauthApiBaseUrl + "subreddits/mine/subscriber?limit=100&raw_json=1", token)).Data.Children.Select(x => x.Data).ToList();
        }
    }
}
