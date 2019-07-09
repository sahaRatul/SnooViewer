using RedditSharp.Things;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnooViewer.Interfaces
{
    public interface IIncrementalSource<T>
    {
        Task<IEnumerable<T>> GetPagedItems(Subreddit subreddit, string subReddit = "all", string commentId = "", string getByCriteria = "hot", uint pageSize = 10);
    }
}
