using RedditSharp.Things;
using SnooViewer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnooViewer.Helpers
{
    public class SubredditPostSource : IIncrementalSource<Post>
    {
        public Subreddit.Sort Sort { get; set; }

        public Task<IEnumerable<Post>> GetPagedItems(Subreddit subreddit, Subreddit.Sort sortCriteria = Subreddit.Sort.Hot, uint itemsPerPage = 10)
        {
            return Task.Run<IEnumerable<Post>>(() =>
            {
                var postList = subreddit.GetPosts(max: 25);
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
