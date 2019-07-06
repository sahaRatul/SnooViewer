using LibSnoo;
using LibSnoo.Models;
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
        private readonly IncrementalLoadingCollection<PostCommentSource, MainDataViewModel> commentList = null;
        private MainDataViewModel selectedPost = null;

        public PostPage()
        {
            this.InitializeComponent();
            commentList = new IncrementalLoadingCollection<PostCommentSource, MainDataViewModel>(LibSnoo.Models.DataContext.Token);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedPost = e.Parameter as MainDataViewModel;
            commentList.CommentId = selectedPost.Id;
            commentList.SubReddit = selectedPost.Subreddit;
        }
    }
}
