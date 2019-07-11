using SnooViewer.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using RedditSharp.Things;
using SnooViewer.Models;

namespace SnooViewer.Pages
{
    /// <summary>
    /// This page displays list of posts in a subreddit.
    /// </summary>
    public sealed partial class SubredditPage : Page
    {
        public Subreddit selectedSubreddit = null;
        private SortCategory selectedSortCategory = Constants.Constants.postSortList.Find(x => x.SortValue == Subreddit.Sort.Hot);
        private object selectedItem = null;

        public IncrementalLoadingCollection<SubredditPostSource, Post> Posts { get; set; } = null;

        public SubredditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedSubreddit = e.Parameter as Subreddit;
            Posts = new IncrementalLoadingCollection<SubredditPostSource, Post>(selectedSubreddit);
        }

        private void PostList_ItemClick(object _, ItemClickEventArgs e)
        {
            if(postColDef.Width.Value == 0 && selectedItem != e.ClickedItem)//Open
            {
                anotherResizerColDef.Width = new GridLength(20);
                postColDef.Width = new GridLength(((ActualWidth * 3 / 5) + 20), GridUnitType.Pixel);
                selectedItem = e.ClickedItem;
                postFrame.Navigate(typeof(PostPage), e.ClickedItem);
            }
            else if(postColDef.Width.Value != 0 && selectedItem != e.ClickedItem) //Keep open if user selected another post
            {
                selectedItem = e.ClickedItem;
                postFrame.Navigate(typeof(PostPage), e.ClickedItem);
            }
            else //Close
            {
                anotherResizerColDef.Width = new GridLength(0);
                postColDef.Width = new GridLength(0, GridUnitType.Star);
                selectedItem = null;
            }
        }

        private void GridSeparator_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            postList.Visibility = Visibility.Collapsed;
            postFrame.Visibility = Visibility.Collapsed;
        }

        private void GridSeparator_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            postList.Visibility = Visibility.Visible;
            postFrame.Visibility = Visibility.Visible;
        }

        private void PostSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedSortCategory = ((ComboBox)sender).SelectedItem as SortCategory;

            //Clear post list and close right panel if open
            Posts.Clear();
            anotherResizerColDef.Width = new GridLength(0);
            postColDef.Width = new GridLength(0, GridUnitType.Star);
            selectedItem = null;

            Posts.SetSortCriteria(selectedSortCategory.SortValue);
        }
    }
}
