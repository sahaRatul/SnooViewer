﻿using LibSnoo;
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
        readonly IncrementalLoadingCollection<SubredditPostSource, PostOrSubRedditDataViewModel> posts = null;
        public PostOrSubRedditDataViewModel selectedSubreddit = null;
        public ApiCalls ApiCalls;
        public SubredditPage()
        {
            this.InitializeComponent();
            posts = new IncrementalLoadingCollection<SubredditPostSource, PostOrSubRedditDataViewModel>(LibSnoo.Models.DataContext.Token);
            ApiCalls = new ApiCalls();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = e.Parameter as PostOrSubRedditDataViewModel ?? new PostOrSubRedditDataViewModel { DisplayName = "all", Url = "/r/all", IconImg = "ms-appx:///Assets/RedditLogo.png", Description = "" };
            if (selectedSubreddit.DisplayName == "all")
            {
                subRedditPageGrid.Children.Remove(separator);
                subRedditPageGrid.Children.Remove(sideBar);
            }
            postList.Header = selectedSubreddit;
            posts.SubReddit = selectedSubreddit.DisplayName;
        }
    }
}
