using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather_Report.Models;

namespace Weather_Report.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.AsQueryable().ToListAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> query)
        {
            return await _dbSet.FirstOrDefaultAsync(query);
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> query)
        {
            return await _dbSet.Where(query).ToListAsync();
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
