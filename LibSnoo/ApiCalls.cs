using LibSnoo.Models;
using LibSnoo.Utils;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<MainDataViewModel>> GetCommentsForPost(string postId, string token, string subreddit = "all", int pageSize = 100, int depth = 10, string getByCriteria = "confidence")
        {
            var url = Constants.Constants.redditOauthApiBaseUrl + "r/" + subreddit + "/comments/" + postId + "?limit=" + pageSize.ToString() + "&depth=" + depth.ToString() + "&raw_json=1" + "&sort=" + getByCriteria;
            List<KindViewModel> result = await httpClient.GetAsync<List<KindViewModel>>(url, token);
            List<MainDataViewModel> retList = new List<MainDataViewModel>();

            retList.AddRange(result[0].Data.Children.Select(x => x.Data).ToList());
            var tempList = Shallower(result[1].Data.Children.Select(x => x.Data).ToList(), 0);
            foreach (var item in tempList)
            {
                retList.AddRange(DepthFirstTraversal(item));
            }

            return retList;
        }

        private List<MainDataViewModel> Shallower(List<MainDataViewModel> list, int depth)
        {
            foreach (MainDataViewModel item in list)
            {
                if (item.Replies != null && item.Replies.Data.Children.Count > 0)
                {
                    List<MainDataViewModel> test = item.Replies.Data.Children.Select(x => x.Data).ToList();
                    item.RepliesShallow = Shallower(test, (depth + 1));
                }
                else
                {
                    item.RepliesShallow = new List<MainDataViewModel>();
                }
                item.Depth = depth;
            }
            return list;
        }

        public IEnumerable<MainDataViewModel> DepthFirstTraversal(MainDataViewModel node)
        {
            Stack<MainDataViewModel> nodes = new Stack<MainDataViewModel>();
            nodes.Push(node);

            while (nodes.Count > 0)
            {
                var n = nodes.Pop();
                yield return n;

                for (int i = n.RepliesShallow.Count - 1; i >= 0; i--)
                    nodes.Push(n.RepliesShallow[i]);
            }
        }
    }
}
