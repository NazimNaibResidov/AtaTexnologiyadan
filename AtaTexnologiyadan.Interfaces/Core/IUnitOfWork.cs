using System;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Interfaces.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepstory<T> Repository<T>() where T : class;

        bool Commit();

        Task<bool> CommitAsync();

        void Rollback();
    }
}