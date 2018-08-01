using System;
using System.Threading.Tasks;
using TSI.DAL.DataContext;

namespace TSI.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private TSIDataContext _dbContext;

        public UnitOfWork(TSIDataContext context)
        {
            _dbContext = context;
        }

        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
        }
    }
}
