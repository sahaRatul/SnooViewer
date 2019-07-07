using LibSnoo;
using LibSnoo.Models;
using RedditSharp.Things;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SnooViewer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostPage : Page
    {
        private readonly ObservableCollection<MainDataViewModel> commentTree = null;
        private readonly ApiCalls apiCalls = null;
        private Post selectedPost = null;
        Thickness x = new Thickness(20, 0, 0, 0);

        public PostPage()
        {
            this.InitializeComponent();
            commentTree = new ObservableCollection<MainDataViewModel>();
            apiCalls = new ApiCalls();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedPost = e.Parameter as Post;
            var commentList = await apiCalls.GetCommentsForPost(selectedPost.Id, LibSnoo.Models.DataContext.Token);

            foreach(MainDataViewModel comment in commentList.GetRange(1, commentList.Count - 1))
            {
                comment.Padding = new Thickness(10 + (comment.Depth.GetValueOrDefault() * 20), 0, 5, 0);
                commentTree.Add(comment);
            }
        }
    }
}
