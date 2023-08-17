

using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.Persistence.Contracts;
namespace BlogApi.Infrastructure.Prersistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class{
    
}

// public class GenericRepository<T> : IGenericRepository<T> where T: class
// {
//     private readonly BlogApiDbContext _context;
//     public GenericRepository(BlogApiDbContext context)
//     {
//         _context = context;
//     }  
// } 