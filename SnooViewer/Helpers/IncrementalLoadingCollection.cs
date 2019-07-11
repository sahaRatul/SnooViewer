using RedditSharp.Things;
using SnooViewer.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SnooViewer.Helpers
{
    public class IncrementalLoadingCollection<T, I> : ObservableCollection<I>, ISupportIncrementalLoading where T : IIncrementalSource<I>, new()
    {
        public Subreddit Subreddit { get; private set; }
        public bool HasMoreItems { get; private set; }
        public Subreddit.Sort SortCriteria { get; set; }
        public T Source { get; }
        public uint ItemsPerPage { get; set; }

        public void SetSubreddit(Subreddit value) => Subreddit = value;
        public void SetSortCriteria(Subreddit.Sort value) => SortCriteria = value;
        public uint GetItemsPerPage() => ItemsPerPage;
        public void SetItemsPerPage(uint value) => ItemsPerPage = value;

        public IncrementalLoadingCollection(Subreddit subreddit, Subreddit.Sort sortCriteria = Subreddit.Sort.Hot, uint itemsPerPage = 10)
        {
            Source = new T();
            SetSubreddit(subreddit);
            SetSortCriteria(sortCriteria);
            SetItemsPerPage(itemsPerPage);
            HasMoreItems = true;
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            var dispatcher = Window.Current.Dispatcher;

            return Task.Run(async () =>
            {
                var result = await Source.GetPagedItems(Subreddit, SortCriteria, ItemsPerPage);
                if (result == null || result.Count() == 0)
                {
                    HasMoreItems = false;
                }
                else
                {
                    await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        foreach (I item in result)
                        {
                            Add(item);
                        }
                    });
                }
                return new LoadMoreItemsResult() { Count = GetItemsPerPage() };
            }).AsAsyncOperation();
        }
    }
}
