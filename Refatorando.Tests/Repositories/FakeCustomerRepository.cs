using Refatorando.Domain.Entities;
using Refatorando.Domain.Repositories;

namespace Refatorando.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {   
        
        public IEnumerable<Customer> Get(IEnumerable<Customer> names)
        {   
            IList<Customer> customers = new List<Customer>();
            customers.Add(new Customer("fabio neves", "fabio@gmail.com"));
            customers.Add(new Customer("carol neves", "carol@gmail.com"));
            customers.Add(new Customer("bruno freitas", "bruno@gmail.com"));
            customers.Add(new Customer("ana", "bruno@gmail.com"));
            customers.Add(new Customer("fabi", "bruno@gmail.com"));


            return customers;
        }
    }
}