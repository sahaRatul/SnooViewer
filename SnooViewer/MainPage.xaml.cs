using LibSnoo;
using LibSnoo.Constants;
using LibSnoo.Models;
using System;
using System.Linq;
using System.Web;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SnooViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly static string clientId = "84uK1BRyofwcVw";
        private readonly static string clientSecret = "V5oWEHWvoKXee9Dwi6W_q6ehoCw";
        private readonly Login login = new Login(clientId, clientSecret);
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
            var scopes = Constants.scopeList.Aggregate("", (acc, x) => acc + " " + x);
            var urlParams = "client_id=" + clientId + "&response_type=code&state=uyagsjgfhjs&duration=permanent&redirect_uri=" + HttpUtility.UrlEncode("http://127.0.0.1:3000/reddit_callback") + "&scope=" + HttpUtility.UrlEncode(scopes);
            Uri targetUri = new Uri(Constants.redditApiBaseUrl + "authorize?" + urlParams);
            loginView.Navigate(targetUri);
        }

        private async void RefreshToken()
        {
            //Refresh Token flow
            var result = await login.Login_Refresh((string)localSettings.Values["refresh_token"]);
            LibSnoo.Models.DataContext.Token = result.AccessToken;
            LibSnoo.Models.DataContext.RefreshToken = result.RefreshToken;
        }

        private async void LoginView_NavigationStarting(WebView _, WebViewNavigationStartingEventArgs args)
        {
            if (args.Uri.AbsoluteUri.Contains("http://127.0.0.1:3000/reddit_callback"))
            {
                var result = await login.Login_Stage2(args.Uri);
                LibSnoo.Models.DataContext.Token = result.AccessToken;
                LibSnoo.Models.DataContext.RefreshToken = result.RefreshToken;
                args.Cancel = true;
                localSettings.Values["refresh_token"] = LibSnoo.Models.DataContext.RefreshToken;
                navBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                loginView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void NavBar_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
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
                contentFrame.NavigateToType(pageType, new PostOrSubRedditDataViewModel { DisplayName = "all", Url = "/r/all", IconImg = "ms-appx:///Assets/RedditLogo.png", Description = "" }, navOptions);
            }
            else if ((string)args.InvokedItem == "Profile")
            {
                pageType = typeof(Pages.UserPage);
                contentFrame.NavigateToType(pageType, null, navOptions);
            }
        }
    }
}
