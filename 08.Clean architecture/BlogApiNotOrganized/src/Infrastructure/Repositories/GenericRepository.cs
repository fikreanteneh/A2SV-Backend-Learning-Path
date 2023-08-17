

using BlogApi.Application.Persistence.Contracts;
using BlogApi.Infrastructure.Prersistance.Repositories;
namespace BlogApi.Infrastructure.Prersistance.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    private readonly BlogApiDbContext  
} 