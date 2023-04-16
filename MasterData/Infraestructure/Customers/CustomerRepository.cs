using DDDSample1.Domain.Customers;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;

namespace DDDSample1.Infraestructure.Customers
{
    public class CustomerRepository: BaseRepository<Customer, CustomerId>, ICustomerRepository
    {
         private readonly DbSet<Customer> _contextJ;

         public CustomerRepository(DDDSample1DbContext context):base(context.Customers)
        {
           _contextJ = context.Customers;
        }

       public async Task<List<Customer>> GetByCompanyAsync(string Company){

        var rec = await this._contextJ.Where(u=> u.Company.Equals(Company)).ToListAsync();
        
        return rec;
       }

   public async Task<Customer> GetByEmailPassAsync(string user, string password)
        {

            var rec = await this._contextJ.SingleOrDefaultAsync(u => u.CustomerEmail.Email == user && u.Password == password);

            return rec;
        }


    }
}