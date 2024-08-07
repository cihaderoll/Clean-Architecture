using CleanArchitectrure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        string DenemeKeyedService();
    }
}
