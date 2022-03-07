using UniAdmin.Contracts.Data;
using UniAdmin.Contracts.Data.Repositories;
using UniAdmin.Infrastructure.Data.Repositories;

namespace UniAdmin.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IDealRepository Deals => new DealRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}