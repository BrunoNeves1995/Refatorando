using Refatorando.Domain.Entities;

namespace Refatorando.Domain.Repositories
{
    public interface IDescountRepository
    {
        Discount Get(string code);
    }
}