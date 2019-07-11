using RedditSharp.Things;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnooViewer.Interfaces
{
    public interface IIncrementalSource<T>
    {
        Task<IEnumerable<T>> GetPagedItems(Subreddit subreddit, Subreddit.Sort sortCriteria = Subreddit.Sort.Hot, uint itemsPerPage = 10);
    }
}
