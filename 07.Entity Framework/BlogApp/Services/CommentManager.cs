

using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Validator;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services;

public class CommentManager {
    private readonly ApiDbContext _context;
    public CommentManager(ApiDbContext context) {
        _context = context;
    }
    public Comment CreateComment(Comment comment) {
        _ = _context.Posts.Find(comment.PostId) ?? throw new CustomException("Post not found");
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }

    public Comment UpdateComment(Comment UpdatedComment) {
        Comment old = GetCommentById(UpdatedComment.Id) ?? throw new CustomException("Comment not found");
        old.Text = UpdatedComment.Text;
        _context.SaveChanges();
        return old;
    }

    public void DeleteComment(int id) {
        Comment comment = GetCommentById(id) ?? throw new CustomException("Comment not found");
        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }

    public List<Comment> GetAllComments(int postId) {
        _ = _context.Posts.Find(postId) ?? throw new CustomException("Post not found");
        List<Comment> comments = _context.Comments.Where(c => c.PostId == postId).ToList() ?? throw new CustomException("Post not found");
        return comments;
    }

    public Comment GetCommentById(int id) {
        Comment comment = _context.Comments.Find(id) ?? throw new CustomException("Comment not found");
        return comment;
    }
}