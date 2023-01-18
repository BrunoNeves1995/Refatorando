using Refatorando.Domain.Entities;

namespace Refatorando.Domain.Repositories
{
    public interface ICustomerRepository
    {
      
        IEnumerable<Customer> Get(IEnumerable<Customer> name);
        
    }
}