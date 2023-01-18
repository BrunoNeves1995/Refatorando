using Refatorando.Domain.Entities;

namespace Refatorando.Domain.Repositories
{
    public interface IOrderREpository
    {
        void Save(Order order);
      
    }
}