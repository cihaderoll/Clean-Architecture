using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Persistence.Contexts;
using CleanArchitectrure.Persistence.Repositories.NonCached;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitectrure.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        #region Repositories

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        #endregion Repositories
    }
}
