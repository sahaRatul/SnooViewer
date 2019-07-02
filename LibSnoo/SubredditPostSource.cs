using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibSnoo.Models;
using LibSnoo.Utils;

namespace LibSnoo
{
    public class SubredditPostSource : IIncrementalSource<PostOrSubRedditDataViewModel>
    {
        private readonly HttpClient httpClient;
        private string after;
        private string subReddit;
        private string getByCriteria;
        public SubredditPostSource()
        {
            httpClient = new HttpClient();
        }

        public Task<IEnumerable<PostOrSubRedditDataViewModel>> GetPagedItems(string token, string subReddit = "all", string getByCriteria = "hot", uint pageSize = 10)
        {
            return Task.Run<IEnumerable<PostOrSubRedditDataViewModel>>(async () =>
            {
                this.after = (this.subReddit != subReddit || this.getByCriteria != getByCriteria) ? "" : this.after; //Reset after if sub or getByCriteria changes
                this.subReddit = subReddit;
                this.getByCriteria = getByCriteria;
                var url = Constants.Constants.redditOauthApiBaseUrl + "r/" + subReddit  + "/" + getByCriteria + "?limit=" + pageSize.ToString() + "&after=" + this.after;
                var result = (await httpClient.GetAsync<KindViewModel>(url, token));
                this.after = result.Data.After;
                return result.Data.Children.Select(x => x.Data).ToList();
            });
        }
    }
}
