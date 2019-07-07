using LibSnoo;
using LibSnoo.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SnooViewer.Pages
{
    /// <summary>
    /// This page displays list of posts in a subreddit.
    /// </summary>
    public sealed partial class SubredditPage : Page
    {
        readonly IncrementalLoadingCollection<SubredditPostSource, MainDataViewModel> posts = null;
        public MainDataViewModel selectedSubreddit = null;
        public ApiCalls ApiCalls;
        private object selectedItem = null;

        public SubredditPage()
        {
            this.InitializeComponent();
            posts = new IncrementalLoadingCollection<SubredditPostSource, MainDataViewModel>(LibSnoo.Models.DataContext.Token);
            ApiCalls = new ApiCalls();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = e.Parameter as MainDataViewModel ?? new MainDataViewModel { DisplayName = "all", Url = "/r/all", IconImg = "ms-appx:///Assets/RedditLogo.png", Description = "" };
            if (selectedSubreddit.DisplayName == "all")
            {
                subRedditPageGrid.Children.Remove(separator);
                subRedditPageGrid.Children.Remove(sideBar);
            }
            postList.Header = selectedSubreddit;
            posts.SubReddit = selectedSubreddit.DisplayName;
        }

        private void HeaderText_Tapped(object _, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (selectedSubreddit.DisplayName != "all")
            {
                if (sidebarColDef.Width.Value == 0)
                {
                    resizerColDef.Width = new GridLength(11);
                    sidebarColDef.Width = new GridLength(250);
                }
                else
                {
                    resizerColDef.Width = new GridLength(0);
                    sidebarColDef.Width = new GridLength(0);
                }
            }
        }

        private void PostList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(postColDef.Width.Value == 0)//Open
            {
                anotherResizerColDef.Width = new GridLength(20);
                resizerColDef.Width = new GridLength(0);
                sidebarColDef.Width = new GridLength(0);
                postColDef.Width = new GridLength(100, GridUnitType.Star);
                selectedItem = e.ClickedItem;
                postFrame.Navigate(typeof(PostPage), e.ClickedItem);
            }
            else//Close
            {
                anotherResizerColDef.Width = new GridLength(0);
                postColDef.Width = new GridLength(0, GridUnitType.Star);
            }
        }
    }
}
