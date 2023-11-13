using Microsoft.EntityFrameworkCore;
using BackESPD.Application.Interfaces;
using BackESPD.Persistense.DbContext;
//using System.Data.Entity;
using System.Linq.Expressions;

namespace BackESPD.Persistense.Repositories
{
    public class GenericRepository<T> : IRepositoryAsync<T> where T : class
    {
        private readonly BackESPDDbContext _context;

        public GenericRepository(BackESPDDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filtro, string includeProperties)
        {
            try
            {
                IQueryable<T> queryEntidad = filtro == null ? _context.Set<T>() : _context.Set<T>().Where(filtro);
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryEntidad = queryEntidad.Include(includeProperty);
                }
                return queryEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filtro, string includeProperties = "")
        {
            try
            {
                IQueryable<T> entidad = _context.Set<T>();
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    entidad = entidad.Include(includeProperty);
                }
                return await entidad.FirstOrDefaultAsync(filtro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
