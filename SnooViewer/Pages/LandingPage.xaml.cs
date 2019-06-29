using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using LibSnoo.Models;
using LibSnoo.Constants;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

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
        readonly Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        public LandingPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            loadingRing.IsActive = true;
            var userDetails = await httpClient.GetAsync<UserViewModel>(Constants.redditOauthApiBaseUrl + "api/v1/me", LibSnoo.Models.DataContext.Token);
            var test = JsonConvert.SerializeObject(userDetails);
            List<SubredditViewModel> retrievedSubReddits = null;

            Windows.Storage.StorageFile subredditFile = null;
            //Retrieve from storage if available
            try
            {
                subredditFile = await storageFolder.GetFileAsync("subreddits.txt");
            }
            catch (Exception)
            {
                subredditFile = await storageFolder.CreateFileAsync("subreddits.txt");
            }
            string text = await Windows.Storage.FileIO.ReadTextAsync(subredditFile);
            if (text == null || text == string.Empty)
            {
                retrievedSubReddits = (await httpClient.GetAsync<KindViewModel>(Constants.redditOauthApiBaseUrl + "subreddits/mine/subscriber?limit=100", LibSnoo.Models.DataContext.Token)).Data.Children.Select(x => x.Data).ToList();
                await Windows.Storage.FileIO.WriteTextAsync(subredditFile, JsonConvert.SerializeObject(retrievedSubReddits));
            }
            else
            {
                retrievedSubReddits = JsonConvert.DeserializeObject<List<SubredditViewModel>>(text);
            }

            foreach (var subreddit in retrievedSubReddits)
            {
                subreddit.KeyColor = subreddit.KeyColor == "" ? subreddit.PrimaryColor == "" ? "#111111" : subreddit.PrimaryColor : subreddit.KeyColor;
                SubReddits.Add(subreddit);
            }

            loadingRing.IsActive = false;
            userName.Text = "Hi! " + userDetails.Name;
        }
    }
}
