using UniAdmin.Contracts.Data.Repositories;

namespace UniAdmin.Contracts.Data
{
    public interface IUnitOfWork
    {
        IDealRepository Deals { get; }
        Task CommitAsync();
    }
}