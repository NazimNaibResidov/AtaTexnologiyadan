using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Persistence;
using AtaTexnologiyadan.Repostorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        private MainDataDBContext _context;

        public UnitOfWork(MainDataDBContext context)
        {
            _context = context;
        }

        public IBaseRepstory<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IBaseRepstory<T>;
            }

            IBaseRepstory<T> repo = new BaseRepstory<T>(_context);

            Repositories.Add(typeof(T), repo);

            return repo;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var data = ex.InnerException;
                Rollback();
                return false;
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                var data = ex.InnerException;
                Rollback();
                return false;
            }
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}