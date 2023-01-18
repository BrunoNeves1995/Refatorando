using System.Linq.Expressions;
using Refatorando.Domain.Entities;

namespace Refatorando.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetActiveProducts()
        {
            return x => x.Active;
        }

         public static Expression<Func<Product, bool>> GetInactiveProducts()
        {
            return x => x.Active == false;
        }

    }
}