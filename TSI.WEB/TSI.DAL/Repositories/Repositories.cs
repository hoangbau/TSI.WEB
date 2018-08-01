using TSI.DAL.DataContext;
using TSI.DAL.Models;
using TSI.DAL.Repositories.Base;

namespace TSI.DAL.Repositories
{
    public class InstroductionRepository : GenericRepository<Instroductions>, IInstroductionRepository
    {
        public InstroductionRepository(TSIDataContext dbContext) : base(dbContext)
        {
        }
    }
}
