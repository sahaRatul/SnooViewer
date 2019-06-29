using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestUWPApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestUWPApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        private readonly HttpClient httpClient = new HttpClient();
        ObservableCollection<SubredditViewModel> SubReddits { get; } = new ObservableCollection<SubredditViewModel>();
        private readonly string redditOauthApiBaseUrl = "https://oauth.reddit.com/";
        public LandingPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            loadingRing.IsActive = true;
            var userDetails = await httpClient.GetAsync<UserViewModel>(redditOauthApiBaseUrl + "api/v1/me", Models.DataContext.Token);
            var retrievedSubReddits = (await httpClient.GetAsync<KindViewModel>(redditOauthApiBaseUrl + "subreddits/mine/subscriber", Models.DataContext.Token)).Data.Children.Select(x => x.Data).ToList();
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
