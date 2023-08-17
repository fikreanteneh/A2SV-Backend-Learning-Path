


using System.Collections.Generic;
using BlogApi.Domain;
namespace BlogApi.Application.Contracts.Persistence;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetByPost(int id);
}