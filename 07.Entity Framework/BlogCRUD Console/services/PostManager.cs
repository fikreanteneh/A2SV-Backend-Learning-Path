

public class PostManager{

    private readonly BlogContext _context;

    public PostManager(BlogContext context){
        _context = context;
    }

    public void CreatePost(Post post){
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public void UpdatePost(Post UpdatedPost){

        Post? old = this.GetPostById(UpdatedPost.Id);
        if (old == null) return;
        old.Title = UpdatedPost.Title;
        old.Content = UpdatedPost.Content;
        _context.SaveChanges();
    }

    public void DeletePost(Post post){
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }

    public List<Post> GetAllPosts(){
        return _context.Posts.ToList();
    }
    public Post? GetPostById(int id){
        return _context.Posts.Find(id);
    }
}