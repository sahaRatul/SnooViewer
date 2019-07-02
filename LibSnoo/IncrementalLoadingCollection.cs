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
        private string GetByCriteria { get; set; }
        public bool HasMoreItems { get; private set; }

        public IncrementalLoadingCollection(string token, string subReddit = "all", string getByCriteria = "hot", uint itemsPerPage = 10)
        {
            this.source = new T();
            this.Token = token;
            this.SubReddit = subReddit;
            this.GetByCriteria = getByCriteria;
            this.ItemsPerPage = itemsPerPage;
            this.HasMoreItems = true;
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            var dispatcher = Window.Current.Dispatcher;

            return Task.Run<LoadMoreItemsResult>(async () =>
            {
                var result = await source.GetPagedItems(Token, SubReddit, GetByCriteria, count);
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
            }).AsAsyncOperation<LoadMoreItemsResult>();
        }
    }
}
