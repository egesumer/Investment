using System.Linq.Expressions;
using System.Threading.Tasks;

public interface IRepository<T> where T : class
{
    Task<bool> AddAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    
    Task<IEnumerable<T>> GetAllAsync(bool includeDeleted = false);
    Task<T> GetByIDAsync(Guid id, bool includeDeleted = false);
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false);
}
