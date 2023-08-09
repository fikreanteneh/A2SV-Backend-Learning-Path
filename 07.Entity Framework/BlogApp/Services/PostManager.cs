

using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Validator;

namespace BlogApp.Services;

public class PostManager{

    private readonly ApiDbContext _context;

    public PostManager(ApiDbContext context){
        _context = context;
    }

    public Post CreatePost(Post post){
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    public Post UpdatePost(Post UpdatedPost){
        Post old = GetPostById(UpdatedPost.Id) ?? throw new CustomException("Post not found");
        old.Title = UpdatedPost.Title;
        old.Content = UpdatedPost.Content;
        _context.SaveChanges();
        return old;
    }

    public void DeletePost(int id){
        Post post = GetPostById(id) ?? throw new CustomException("Post not found");
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }

    public List<Post> GetAllPosts(){
        return _context.Posts.ToList();
    }
    public Post GetPostById(int id){
        Post post = _context.Posts.Find(id) ?? throw new CustomException("Post not found");
        return post; 
    }
}