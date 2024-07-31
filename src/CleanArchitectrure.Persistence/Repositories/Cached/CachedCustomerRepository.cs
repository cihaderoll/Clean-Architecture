using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Entities;
using CleanArchitectrure.Persistence.Contexts;
using CleanArchitectrure.Persistence.Repositories.NonCached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Persistence.Repositories.Cached
{
    public class CachedCustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerRepository _customerRepository;

        public CachedCustomerRepository(AppDbContext context, 
                                        CustomerRepository customerRepository) : base(context)
        {
            _customerRepository = customerRepository;
        }
    }
}
