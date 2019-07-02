using LibSnoo;
using LibSnoo.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SnooViewer.Pages
{
    /// <summary>
    /// This page displays list of posts in a subreddit.
    /// </summary>
    public sealed partial class SubredditPage : Page
    {
        readonly IncrementalLoadingCollection<SubredditPostSource, PostOrSubRedditDataViewModel> posts = new IncrementalLoadingCollection<SubredditPostSource, PostOrSubRedditDataViewModel>(LibSnoo.Models.DataContext.Token);
        public PostOrSubRedditDataViewModel selectedSubreddit = null;

        public SubredditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = e.Parameter as PostOrSubRedditDataViewModel ?? new PostOrSubRedditDataViewModel { DisplayName = "all", Url = "/r/all" };
            postList.Header = selectedSubreddit;
            posts.SubReddit = selectedSubreddit.DisplayName;
        }
    }
}
