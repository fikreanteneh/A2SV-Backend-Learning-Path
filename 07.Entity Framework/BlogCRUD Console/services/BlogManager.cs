class BlogManager {
    private static BlogContext _context = new BlogContext();
    private PostManager _postManager = new PostManager(_context);
    private CommentManager _commentManager = new CommentManager(_context);

    public void DisplayPosts(){
        List<Post> posts =  _postManager.GetAllPosts();
        foreach (Post post in posts){
            Formater.FormatPost(post);
        }
    }

    public void DisplayPostDetail(int postId){
        Post? post = _postManager.GetPostById(postId);
        if (post == null) {
            Formater.FormatError("Post not found!!!");
            return;
        };
        List<Comment> coments = _commentManager.GetAllComments(post.Id);
        Formater.FormatPostDetil(post);
        foreach (Comment comment in coments){
            Formater.FormatComment(comment);
        }
    }

    public void CreatePost(string title, string content){
        _postManager.CreatePost(
            new Post{
                Title = title,
                Content = content,
            }
        );
    }

    public void UpdatePost(int id, string title, string content){
        Post? post = _postManager.GetPostById(id);
        if (post == null) {
            Formater.FormatError("Post not found!!!");
            return;
        }
        _postManager.UpdatePost(
            new Post{
                Id = id,
                Title = title.Length == 0 ? post.Title : title,
                Content = content.Length == 0 ? post.Content : content,
            }
        );
    }

    public void DeletePost(int id){
        Post? post = _postManager.GetPostById(id);
        if (post == null){
            Formater.FormatError("Post not found!!!");
            return;
        };
        _postManager.DeletePost(post);
    }

    public void CreateComment(int postId, string text){
        _commentManager.CreateComment(
            new Comment{
                PostId = postId,
                Text = text,
            }
        );
    }

    public void UpdateComment(int id, int postId, string text){
        Comment? comment = _commentManager.GetCommentById(id);
        if (comment == null) {
            Formater.FormatError("Comment not found!!!");
            return;
        };
        _commentManager.UpdateComment(
            new Comment{
                Id = id,
                PostId = postId,
                Text = text
            }
        );
    }

    public void DeleteComment(int id){
        Comment? comment = _commentManager.GetCommentById(id);
        if (comment == null) {
            Formater.FormatError("Comment not found!!!");
            return;
        };
        if (comment == null) return;
        _commentManager.DeleteComment(comment);
    }

}