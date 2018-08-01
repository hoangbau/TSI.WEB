using System;
using System.Threading.Tasks;

namespace TSI.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        Task<bool> CommitAsync();
    }
}
