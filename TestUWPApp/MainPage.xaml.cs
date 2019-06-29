using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Windows.UI.Xaml.Controls;

namespace SnooViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly string redditApiBaseUrl = "https://www.reddit.com/api/v1/";

        public MainPage()
        {
            this.InitializeComponent();
            this.Login();
        }

        private void Login()
        {
            var scopes = Constants.Constants.scopeList.Aggregate("", (acc, x) => acc + " " + x);
            var urlParams = "client_id=X70tYeVZG2rz8g&response_type=token&state=uyagsjgfhjs&redirect_uri=" + HttpUtility.UrlEncode("http://127.0.0.1:3000/reddit_callback") + "&scope=" + HttpUtility.UrlEncode(scopes);
            Uri targetUri = new Uri(redditApiBaseUrl + "authorize?" + urlParams);
            loginView.Navigate(targetUri);
        }

        private void LoginView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if(args.Uri.AbsoluteUri.Contains("http://127.0.0.1:3000/reddit_callback"))
            {
                var regex = new Regex(Regex.Escape("#"));
                var updatedUriStr = regex.Replace(args.Uri.AbsoluteUri, "?", 1);
                var updatedUri = new Uri(updatedUriStr);
                Models.DataContext.Token = HttpUtility.ParseQueryString(updatedUri.Query).Get("access_token");
                args.Cancel = true;
                this.Frame.Navigate(typeof(Pages.LandingPage));
            }
        }
    }
}
