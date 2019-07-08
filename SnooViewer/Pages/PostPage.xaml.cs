using RedditSharp.Things;
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
        private readonly ObservableCollection<Thing> commentTree = null;
        private Post selectedPost = null;

        public PostPage()
        {
            this.InitializeComponent();
            commentTree = new ObservableCollection<Thing>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedPost = e.Parameter as Post;
            List<Thing> commentsWithMores = await selectedPost.GetCommentsWithMoresAsync(100);
            foreach (var comment in commentsWithMores)
            {
                if (comment is Comment) //Assign Depth & Flatten tree
                {
                    AssignCommentDepth((comment as Comment).Comments);
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

        public void AssignCommentDepth(IList<Thing> commentTree, uint depth = 1)
        {
            foreach (var thing in commentTree)
            {
                if(thing is Comment)
                {
                    (thing as Comment).Depth = depth;
                    if ((thing as Comment).Comments.Count > 0)
                    {
                        AssignCommentDepth((thing as Comment).Comments, depth + 1);
                    }
                }
                else if(thing is More)
                {
                    (thing as More).Depth = depth;
                }
            }
        }

        public void DepthFirstTraversal(Comment root, Stack<Thing> stack)
        {
            stack.Push(root);
            foreach(Thing thing in root.Comments)
            {
                if (thing is Comment)
                {
                    DepthFirstTraversal(thing as Comment, stack);
                }
                else if(thing is More)
                {
                    stack.Push(thing);
                }
            }
        }
    }
}
