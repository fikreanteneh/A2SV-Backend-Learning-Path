
namespace LeaveManagment.Application.Persistence.Contracts;


public interface IGenericRepository<T>  where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);

    Task<bool> Exist(int id);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}
