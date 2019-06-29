using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using LibSnoo.Models;
using LibSnoo.Constants;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SnooViewer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        private readonly HttpClient httpClient = new HttpClient();
        ObservableCollection<SubredditViewModel> SubReddits { get; } = new ObservableCollection<SubredditViewModel>();
        public LandingPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            loadingRing.IsActive = true;
            var userDetails = await httpClient.GetAsync<UserViewModel>(Constants.redditOauthApiBaseUrl + "api/v1/me", LibSnoo.Models.DataContext.Token);
            var retrievedSubReddits = (await httpClient.GetAsync<KindViewModel>(Constants.redditOauthApiBaseUrl + "subreddits/mine/subscriber", LibSnoo.Models.DataContext.Token)).Data.Children.Select(x => x.Data).ToList();
            foreach (var subreddit in retrievedSubReddits)
            {
                subreddit.KeyColor = subreddit.KeyColor == "" ? subreddit.PrimaryColor == "" ? "#000000" : subreddit.PrimaryColor : subreddit.KeyColor;
                SubReddits.Add(subreddit);
            }
            loadingRing.IsActive = false;
            userName.Text = "Hi! " + userDetails.Name;
        }
    }
}
