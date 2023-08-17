using BlogApi.Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using BlogApi.Domain;

namespace BlogApi.Infrastructure.Prersistance.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly BlogApiDbContext _dbContext;
    private readonly DbSet<Comment> _dbSet;

    public CommentRepository(BlogApiDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Comment>();
    }
    
    public async Task<List<Comment>> GetByPost(int id)
    {
        var comments = await _dbSet.Where(c => c.PostId == id).ToListAsync();
        return comments;
    }
}