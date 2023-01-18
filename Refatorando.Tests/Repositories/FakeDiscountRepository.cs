using Refatorando.Domain.Entities;
using Refatorando.Domain.Repositories;

namespace Refatorando.Tests.Repositories
{
    public class FakeDiscountRepository : IDescountRepository
    {
        public Discount Get(string code)
        {
            if(code == "22222222")
                return new Discount(DateTime.Now.AddDays(5), 10);
            
            if(code == "11111111")
                return new Discount(DateTime.Now.AddDays(-5), 10);
            
            return null!;
        }
    }
}