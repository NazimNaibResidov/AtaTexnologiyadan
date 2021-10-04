using AtaTexnologiyadan.Cores.CoreRepsotory;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Cores.CoreUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepstory<T> Repository<T>() where T : class;

        bool Commit();
        Task<bool> CommitAsync();

        void Rollback();
    }
}
