using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        #region Repos

        public IUserRepository UserRepository { get; }
        public ICustomerRepository CustomerRepository { get; }

        #endregion Repos

        Task<IDbContextTransaction> BeginTransaction();

        Task Commit();
    }
}
