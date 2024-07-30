using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Entities;
using CleanArchitectrure.Persistence.Contexts;

namespace CleanArchitectrure.Persistence.Repositories
{
    public class CustomerRepository(AppDbContext context) : GenericRepository<Customer>(context), ICustomerRepository
    {
    }
}
