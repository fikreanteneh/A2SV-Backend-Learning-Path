class CommentManager {
    private BlogContext _context;
    public CommentManager(BlogContext context) {
        _context = context;
    }
    public void CreateComment(Comment comment) {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public void UpdateComment(Comment UpdatedComment) {
        Comment? old = this.GetCommentById(UpdatedComment.Id);
        if (old == null) return;
        old.Text = UpdatedComment.Text;
        _context.SaveChanges();
    }

    public void DeleteComment(Comment comment) {
        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }

    public List<Comment> GetAllComments(int postId) {
        return _context.Comments.Where(c => c.PostId == postId).ToList();
    }

    public Comment? GetCommentById(int id) {
        return _context.Comments.Find(id);
    }

    
}