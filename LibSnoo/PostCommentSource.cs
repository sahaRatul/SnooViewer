using LibSnoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSnoo.Utils;

namespace LibSnoo
{
    public class PostCommentSource : IIncrementalSource<MainDataViewModel>
    {
        private readonly HttpClient httpClient;
        private string subReddit;
        private string getByCriteria;

        public PostCommentSource()
        {
            httpClient = new HttpClient();
        }

        public Task<IEnumerable<MainDataViewModel>> GetPagedItems(string token, string subReddit = "all", string commentId = "", string getByCriteria = "hot", uint pageSize = 10)
        {
            return Task.Run<IEnumerable<MainDataViewModel>>(async () =>
            {
                //this.after = (this.subReddit != subReddit || this.getByCriteria != getByCriteria) ? "" : this.after; //Reset after if sub or getByCriteria changes
                this.subReddit = subReddit;
                this.getByCriteria = getByCriteria;
                var url = Constants.Constants.redditOauthApiBaseUrl + "r/" + subReddit + "/" + getByCriteria + "?limit=" + pageSize.ToString() + "&raw_json=1";
                var result = (await httpClient.GetAsync<List<KindViewModel>>(url, token));
                //this.after = result.Data.After;
                return result[1].Data.Children.Select(x => x.Data).ToList();
            });
        }
    }
}
