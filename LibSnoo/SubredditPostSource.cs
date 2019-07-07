using RedditSharp.Things;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibSnoo
{
    public class SubredditPostSource : IIncrementalSource<Post>
    {
        public Task<IEnumerable<Post>> GetPagedItems(Subreddit subreddit, string subReddit = "all", string commentId = "", string getByCriteria = "hot", uint pageSize = 10)
        {
            return Task.Run<IEnumerable<Post>>(() =>
            {
                var postList = subreddit.GetPosts(25);
                List<Post> retVal = new List<Post>();
                postList.ForEach((x) =>
                {
                    retVal.Add(x);
                });
                return retVal;
            });
        }
    }
}
