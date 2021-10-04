using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Repostorys
{
    public class BaseRepstory<T> : IBaseRepstory<T> where T : class
    {
        private MainDataDBContext _context;

        public BaseRepstory(MainDataDBContext context)
        {
            this._context = context;
        }

        #region ::FIND::

        public bool FindAny(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Any(match);
        }

        public async Task<bool> FindAnyAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AnyAsync(match);
        }

        public ICollection<T> FindBy(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public T FindFirst(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(match);
        }

        public T FindById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> FindByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        #endregion ::FIND::

        public IQueryable<T> GetAll()
        {
            var result = _context.Set<T>().AsQueryable();
            return result;
        }

        public async Task<T> CreateAsync(T Entity)
        {
            await _context.AddAsync(Entity);
            return Entity;
        }

        public T Delete(T Entity)
        {
            _context.Remove(Entity);
            return Entity;
        }

        public async Task<bool> Save()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public T Update(T Entity)
        {
            //Set<T>().Attach(updated);
            //_context.Set<T>().Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.Update(Entity);
            return Entity;
        }
    }
}