using RedditSharp.Things;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SnooViewer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostPage : Page
    {
        private readonly ObservableCollection<Thing> commentTree = null;
        private Post selectedPost = null;

        public PostPage()
        {
            InitializeComponent();
            commentTree = new ObservableCollection<Thing>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedPost = e.Parameter as Post;
            List<Thing> commentsWithMores = await selectedPost.GetCommentsWithMoresAsync(100);
            foreach (var comment in commentsWithMores)
            {
                if (comment is Comment) //Flatten tree for list
                {
                    Stack<Thing> flatTree = new Stack<Thing>();
                    DepthFirstTraversal(comment as Comment, flatTree);
                    flatTree.Reverse().ToList().ForEach((x) => commentTree.Add(x));
                }
                else if (comment is More)
                {
                    commentTree.Add(comment);
                }
            }
        }

        public void DepthFirstTraversal(Comment root, Stack<Thing> stack)
        {
            stack.Push(root);
            foreach (Thing thing in root.Comments)
            {
                if (thing is Comment)
                {
                    DepthFirstTraversal(thing as Comment, stack);
                }
                else if (thing is More)
                {
                    stack.Push(thing);
                }
            }
        }

        public static string GetLoadMoreCommentsString(string[] children)
        {
            return "Load " + children.Length + " more comments";
        }

        private async void Comments_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is More)
            {
                var clickedItem = e.ClickedItem as More;
                var Id = clickedItem.Id;
                var index = commentTree.IndexOf(clickedItem);

                //Load all child comments
                var comments = await Task.Run(() => clickedItem.GetThingsAsync());
                List<Thing> tempList = new List<Thing>();

                foreach (var comment in comments)
                {
                    if (comment is Comment) //Flatten tree for listview
                    {
                        Stack<Thing> flatTree = new Stack<Thing>();
                        DepthFirstTraversal(comment as Comment, flatTree);
                        flatTree.Reverse().ToList().ForEach((x) => tempList.Add(x));
                    }
                    else if (comment is More && (comment as More).Children.Count() > 0)
                    {
                        tempList.Add(comment);
                    }
                }

                //Replace more item at index
                commentTree[index] = tempList[0];
                tempList.RemoveAt(0); index++;

                //Insert each item of templist at specific index
                tempList.ForEach((x) =>
                {
                    commentTree.Insert(index, x);
                    index++;
                });
            }
        }
    }
}
