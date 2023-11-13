using System.Linq.Expressions;

namespace BackESPD.Application.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filtro = null, string includeProperties = "");
        Task<T> GetAsync(Expression<Func<T, bool>> filtro, string includeProperties = "");
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
