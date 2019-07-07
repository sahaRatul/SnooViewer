using LibSnoo;
using LibSnoo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using RedditSharp.Things;

namespace SnooViewer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubredditGridPage : Page
    {
        private ObservableCollection<Subreddit> SubReddits { get; } = new ObservableCollection<Subreddit>();
        private readonly Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public SubredditGridPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            loadingRing.IsActive = true;
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

            List<Subreddit> retrievedSubReddits = new List<Subreddit>();
            if (text == null || text == string.Empty)
            {
                //Load subreddits
                if(LibSnoo.Models.DataContext.Reddit.User == null)
                {
                    await LibSnoo.Models.DataContext.Reddit.InitOrUpdateUserAsync();
                }

                RedditSharp.Listing<Subreddit> subListing = LibSnoo.Models.DataContext.Reddit.User.GetSubscribedSubreddits();
                subListing.ForEach(subreddit =>
                {
                    subreddit.IconImage = subreddit.IconImage != string.Empty ? subreddit.IconImage : (subreddit.HeaderImage ?? "ms-appx:///Assets/RedditLogo.png");
                    retrievedSubReddits.Add(subreddit);
                });

                //await Windows.Storage.FileIO.WriteTextAsync(subredditFile, JsonConvert.SerializeObject(retrievedSubReddits));
            }
            else
            {
                JsonConvert.DeserializeObject<List<Subreddit>>(text).ForEach((x) => retrievedSubReddits.Add(x));
            }

            foreach(var subreddit in retrievedSubReddits)
            {
                SubReddits.Add(subreddit);
            }

            loadingRing.IsActive = false;
        }

        private void SubredditList_ItemClick(object sender, ItemClickEventArgs e)
        {
            contentFrame.Navigate(typeof(SubredditPage), e.ClickedItem);
        }

        private void OpenCloseButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }
    }
}
