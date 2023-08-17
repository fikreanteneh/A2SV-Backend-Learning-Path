


using System.Collections.Generic;
using BlogApi.Domain;
namespace BlogApi.Application.Persistence.Contracts;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetByPost(int id);
}