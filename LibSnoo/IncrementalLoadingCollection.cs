using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LibSnoo
{
    public class IncrementalLoadingCollection<T, I> : ObservableCollection<I>, ISupportIncrementalLoading where T : IIncrementalSource<I>, new()
    {
        private readonly T source;
        private uint ItemsPerPage { get; set; }
        public string Token { get; set; }
        public string SubReddit { get; set; }
        public string CommentId { get; set; }
        private string GetByCriteria { get; set; }
        public bool HasMoreItems { get; private set; }

        public IncrementalLoadingCollection(string token, string subReddit = "all", string commentId = "", string getByCriteria = "hot", uint itemsPerPage = 10)
        {
            source = new T();
            Token = token;
            SubReddit = subReddit;
            CommentId = commentId;
            GetByCriteria = getByCriteria;
            ItemsPerPage = itemsPerPage;
            HasMoreItems = true;
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            var dispatcher = Window.Current.Dispatcher;

            return Task.Run(async () =>
            {
                var result = await source.GetPagedItems(Token, SubReddit, CommentId, GetByCriteria, count);
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
                            this.Add(item);
                        }
                    });
                }
                return new LoadMoreItemsResult() { Count = ItemsPerPage };
            }).AsAsyncOperation();
        }
    }
}
