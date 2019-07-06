using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using LibSnoo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using LibSnoo;
using System.Linq;

namespace SnooViewer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubredditGridPage : Page
    {
        private ObservableCollection<PostOrSubRedditDataViewModel> SubReddits { get; } = new ObservableCollection<PostOrSubRedditDataViewModel>();
        private readonly Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        private readonly Landing landing = new Landing();

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

            List<PostOrSubRedditDataViewModel> retrievedSubReddits;
            if (text == null || text == string.Empty)
            {
                retrievedSubReddits = (await landing.GetSubscribedSubreddits(LibSnoo.Models.DataContext.Token)).OrderBy(x => x.Url).ToList();
                await Windows.Storage.FileIO.WriteTextAsync(subredditFile, JsonConvert.SerializeObject(retrievedSubReddits));
            }
            else
            {
                retrievedSubReddits = JsonConvert.DeserializeObject<List<PostOrSubRedditDataViewModel>>(text).OrderBy(x => x.Url).ToList();
            }

            foreach (var subreddit in retrievedSubReddits)
            {
                subreddit.IconImg = subreddit.IconImg != string.Empty ? subreddit.IconImg : (subreddit.HeaderImg ?? "ms-appx:///Assets/RedditLogo.png");
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
