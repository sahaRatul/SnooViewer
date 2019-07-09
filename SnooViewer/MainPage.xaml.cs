//using LibSnoo;
using SnooViewer.Constants;
using SnooViewer.Models;
using RedditSharp;
using System;
using System.Linq;
using System.Web;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SnooViewer.Helpers;

namespace SnooViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly static string clientId = "84uK1BRyofwcVw";
        private readonly static string clientSecret = "V5oWEHWvoKXee9Dwi6W_q6ehoCw";
        private readonly LoginHelper loginHelper = new LoginHelper(clientId, clientSecret);
        private readonly Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
            if ((string)localSettings.Values["refresh_token"] == null)
            {
                navBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                GenerateToken();
            }
            else
            {
                RefreshToken();
                loginView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void GenerateToken()
        {
            var scopes = Constants.Constants.scopeList.Aggregate("", (acc, x) => acc + " " + x);
            var urlParams = "client_id=" + clientId + "&response_type=code&state=uyagsjgfhjs&duration=permanent&redirect_uri=" + HttpUtility.UrlEncode("http://127.0.0.1:3000/reddit_callback") + "&scope=" + HttpUtility.UrlEncode(scopes);
            Uri targetUri = new Uri(Constants.Constants.redditApiBaseUrl + "authorize?" + urlParams);
            loginView.Navigate(targetUri);
        }

        private async void RefreshToken()
        {
            //Refresh Token flow
            var result = await loginHelper.Login_Refresh((string)localSettings.Values["refresh_token"]);
            SnooViewer.DataContext.Token = result.AccessToken;
            SnooViewer.DataContext.RefreshToken = result.RefreshToken;
            SnooViewer.DataContext.Reddit = new Reddit(result.AccessToken);
            await SnooViewer.DataContext.Reddit.InitOrUpdateUserAsync();
        }

        private async void LoginView_NavigationStarting(WebView _, WebViewNavigationStartingEventArgs args)
        {
            if (args.Uri.AbsoluteUri.Contains("http://127.0.0.1:3000/reddit_callback"))
            {
                var result = await loginHelper.Login_Stage2(args.Uri);
                SnooViewer.DataContext.Token = result.AccessToken;
                SnooViewer.DataContext.RefreshToken = result.RefreshToken;
                SnooViewer.DataContext.Reddit = new Reddit(result.AccessToken);
                await SnooViewer.DataContext.Reddit.InitOrUpdateUserAsync();
                args.Cancel = true;
                localSettings.Values["refresh_token"] = SnooViewer.DataContext.RefreshToken;
                navBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                loginView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void NavBar_ItemInvoked(NavigationView _, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions
            {
                TransitionInfoOverride = args.RecommendedNavigationTransitionInfo
            };
            Type pageType;
            if (args.IsSettingsInvoked)
            {
                pageType = typeof(Pages.SettingsPage);
                contentFrame.NavigateToType(pageType, null, navOptions);
            }
            else if ((string)args.InvokedItem == "My Subreddits")
            {
                pageType = typeof(Pages.SubredditGridPage);
                contentFrame.NavigateToType(pageType, null, navOptions);
            }
            else if ((string)args.InvokedItem == "Front Page")
            {
                pageType = typeof(Pages.SubredditPage);
                contentFrame.NavigateToType(pageType, SnooViewer.DataContext.Reddit.FrontPage, navOptions);
            }
            else if ((string)args.InvokedItem == "Profile")
            {
                pageType = typeof(Pages.UserPage);
                contentFrame.NavigateToType(pageType, null, navOptions);
            }
        }
    }
}
