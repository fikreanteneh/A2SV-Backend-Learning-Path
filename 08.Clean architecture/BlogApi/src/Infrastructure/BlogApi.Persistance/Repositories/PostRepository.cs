using BlogApi.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using BlogApi.Domain;

namespace BlogApi.Prersistance.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly BlogApiDbContext _dbContext;
    private readonly DbSet<Post> _dbSet;

    public PostRepository(BlogApiDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Post>();
    }
}