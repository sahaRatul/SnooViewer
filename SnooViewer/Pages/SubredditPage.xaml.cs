using LibSnoo;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using RedditSharp.Things;

namespace SnooViewer.Pages
{
    /// <summary>
    /// This page displays list of posts in a subreddit.
    /// </summary>
    public sealed partial class SubredditPage : Page
    {
        private IncrementalLoadingCollection<SubredditPostSource, Post> posts = null;
        public Subreddit selectedSubreddit = null;
        public ApiCalls ApiCalls;
        private object selectedItem = null;

        public SubredditPage()
        {
            this.InitializeComponent();
            ApiCalls = new ApiCalls();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = e.Parameter as Subreddit;
            
            posts = new IncrementalLoadingCollection<SubredditPostSource, Post>(selectedSubreddit);
            if (selectedSubreddit.DisplayName == "all")
            {
                subRedditPageGrid.Children.Remove(separator);
                subRedditPageGrid.Children.Remove(sideBar);
            }

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

        private void PostList_ItemClick(object _, ItemClickEventArgs e)
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
