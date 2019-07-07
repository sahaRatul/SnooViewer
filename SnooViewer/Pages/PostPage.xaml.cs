using LibSnoo;
using LibSnoo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private MainDataViewModel selectedPost = null;

        public PostPage()
        {
            this.InitializeComponent();
            commentTree = new ObservableCollection<MainDataViewModel>();
            apiCalls = new ApiCalls();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedPost = e.Parameter as MainDataViewModel;
            var commentList = await apiCalls.GetCommentsForPost(selectedPost.Id, LibSnoo.Models.DataContext.Token);

            foreach(MainDataViewModel comment in commentList.GetRange(1, commentList.Count - 1))
            {
                commentTree.Add(comment);
            }
        }
    }
}
