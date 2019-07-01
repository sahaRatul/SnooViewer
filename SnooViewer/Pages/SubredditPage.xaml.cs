using LibSnoo;
using LibSnoo.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SnooViewer.Pages
{
    /// <summary>
    /// This page displays list of posts in a subreddit.
    /// </summary>
    public sealed partial class SubredditPage : Page
    {
        private readonly SubredditPostList subPosts = new SubredditPostList();
        public PostOrSubRedditDataViewModel selectedSubreddit = null;
        private readonly ObservableCollection<PostOrSubRedditDataViewModel> posts = new ObservableCollection<PostOrSubRedditDataViewModel>();
        //private string headerText = "";

        public SubredditPage()
        {
            this.InitializeComponent();
        }

        public async Task GetPosts()
        {
            loadingRing.IsActive = true;
            loadingRing.Visibility = Windows.UI.Xaml.Visibility.Visible;
            postList.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            var posts = await subPosts.GetSubredditPosts(subreddit: selectedSubreddit.DisplayName, token: LibSnoo.Models.DataContext.Token , limit: 25);
            foreach(PostOrSubRedditDataViewModel post in posts)
            {
                this.posts.Add(post);
            }
            loadingRing.IsActive = false;
            loadingRing.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            postList.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = (e.Parameter as PostOrSubRedditDataViewModel) != null ? (e.Parameter as PostOrSubRedditDataViewModel) : new PostOrSubRedditDataViewModel { DisplayName = "all"};
            postList.Header = selectedSubreddit;
        }

        private async void SubredditPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await GetPosts();
        }
    }
}
