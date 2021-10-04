using System;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Cores.CoreService
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepstory<T> Repository<T>() where T : class;

        bool Commit();
        Task<bool> CommitAsync();

        void Rollback();
    }
}
