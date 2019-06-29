using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using LibSnoo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using LibSnoo;
using System.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SnooViewer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        private ObservableCollection<SubredditViewModel> SubReddits { get; } = new ObservableCollection<SubredditViewModel>();
        private readonly Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        private readonly Landing landing = new Landing();

        public LandingPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            loadingRing.IsActive = true;
            searchBox.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            var userDetails = await landing.GetUserDetails(LibSnoo.Models.DataContext.Token);
            Windows.Storage.StorageFile subredditFile;

            //Retrieve from storage if available
            try
            {
                subredditFile = await storageFolder.GetFileAsync("subreddits.txt");
            }
            catch (Exception)
            {
                subredditFile = await storageFolder.CreateFileAsync("subreddits.txt");
            }

            //Read the file
            string text = await Windows.Storage.FileIO.ReadTextAsync(subredditFile);

            List<SubredditViewModel> retrievedSubReddits;
            if (text == null || text == string.Empty)
            {
                retrievedSubReddits = (await landing.GetSubscribedSubreddits(LibSnoo.Models.DataContext.Token)).OrderBy(x => x.Url).ToList();
                await Windows.Storage.FileIO.WriteTextAsync(subredditFile, JsonConvert.SerializeObject(retrievedSubReddits));
            }
            else
            {
                retrievedSubReddits = JsonConvert.DeserializeObject<List<SubredditViewModel>>(text).OrderBy(x => x.Url).ToList();
            }

            foreach (var subreddit in retrievedSubReddits)
            {
                subreddit.KeyColor = subreddit.KeyColor == "" ? subreddit.PrimaryColor == "" ? "#111111" : subreddit.PrimaryColor : subreddit.KeyColor;
                SubReddits.Add(subreddit);
            }

            loadingRing.IsActive = false;
            userName.Text = "Hi, " + userDetails.Name + "!";
            searchBox.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}
