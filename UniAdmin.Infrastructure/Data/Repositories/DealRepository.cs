using UniAdmin.Contracts.Data.Entities;
using UniAdmin.Contracts.Data.Repositories;

namespace UniAdmin.Infrastructure.Data.Repositories
{
    public class DealRepository : Repository<Deal>, IDealRepository
    {
        public DealRepository(DatabaseContext context) : base(context)
        {
        }
    }
}