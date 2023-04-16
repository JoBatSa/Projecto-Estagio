using DDDSample1.Domain.Customers;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using System.Collections.Generic;


namespace DDDSample1.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer, CustomerId>
    {
        
        Task<List<Customer>> GetByCompanyAsync(string company);

         Task<Customer> GetByEmailPassAsync(string user, string pass);
    }
}