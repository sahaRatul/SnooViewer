using System;
using Windows.UI.Xaml.Controls;
using LibSnoo;
using LibSnoo.Constants;
using System.Linq;
using System.Web;

namespace SnooViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Login login = new Login("84uK1BRyofwcVw", "V5oWEHWvoKXee9Dwi6W_q6ehoCw");
        readonly Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public MainPage()
        {
            var clientId = "84uK1BRyofwcVw";
            var clientSecret = "V5oWEHWvoKXee9Dwi6W_q6ehoCw";
            this.InitializeComponent();
            if((string)localSettings.Values["refresh_token"] != null || (string)localSettings.Values["refresh_token"] != string.Empty)
            {
                this.RefreshToken();
            }
            else
            {
                login = new Login(clientId, clientSecret);
                var scopes = Constants.scopeList.Aggregate("", (acc, x) => acc + " " + x);
                var urlParams = "client_id=" + clientId + "&response_type=code&state=uyagsjgfhjs&duration=permanent&redirect_uri=" + HttpUtility.UrlEncode("http://127.0.0.1:3000/reddit_callback") + "&scope=" + HttpUtility.UrlEncode(scopes);
                Uri targetUri = new Uri(Constants.redditApiBaseUrl + "authorize?" + urlParams);
                loginView.Navigate(targetUri);
            }
        }

        private async void RefreshToken()
        {
            //Refresh Token flow
            var result = await login.Login_Refresh((string)localSettings.Values["refresh_token"]);
            LibSnoo.Models.DataContext.Token = result.AccessToken;
            LibSnoo.Models.DataContext.RefreshToken = result.RefreshToken;
            this.Frame.Navigate(typeof(Pages.LandingPage));
        }

        private async void LoginView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (args.Uri.AbsoluteUri.Contains("http://127.0.0.1:3000/reddit_callback"))
            {
                var result = await login.Login_Stage2(args.Uri);
                LibSnoo.Models.DataContext.Token = result.AccessToken;
                LibSnoo.Models.DataContext.RefreshToken = result.RefreshToken;
                args.Cancel = true;
                this.Frame.Navigate(typeof(Pages.LandingPage));
                localSettings.Values["refresh_token"] = LibSnoo.Models.DataContext.RefreshToken;
            }
        }
    }
}
