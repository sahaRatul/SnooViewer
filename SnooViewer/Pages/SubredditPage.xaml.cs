using LibSnoo;
using LibSnoo.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SnooViewer.Pages
{
    /// <summary>
    /// This page displays list of posts in a subreddit.
    /// </summary>
    public sealed partial class SubredditPage : Page
    {
        readonly IncrementalLoadingCollection<SubredditPostSource, PostOrSubRedditDataViewModel> posts = null;
        public PostOrSubRedditDataViewModel selectedSubreddit = null;
        public ObservableCollection<SubredditRuleViewModel> rules = null;
        public ApiCalls ApiCalls;
        public SubredditPage()
        {
            this.InitializeComponent();
            posts = new IncrementalLoadingCollection<SubredditPostSource, PostOrSubRedditDataViewModel>(LibSnoo.Models.DataContext.Token);
            rules = new ObservableCollection<SubredditRuleViewModel>();
            ApiCalls = new ApiCalls();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = e.Parameter as PostOrSubRedditDataViewModel ?? new PostOrSubRedditDataViewModel { DisplayName = "all", Url = "/r/all" };
            postList.Header = selectedSubreddit;
            posts.SubReddit = selectedSubreddit.DisplayName;
            var globalRules = (await ApiCalls.GetRulesForSubreddit(LibSnoo.Models.DataContext.Token, selectedSubreddit.DisplayName));
            foreach(var rule in globalRules.Rules)
            {
                rules.Add(rule);
            }
        }
    }
}
