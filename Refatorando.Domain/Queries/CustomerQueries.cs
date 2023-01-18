using System.Linq.Expressions;
using Refatorando.Domain.Entities;

namespace Refatorando.Domain.Queries
{
    public static class CustomerQueries
    {
        public static Expression<Func<Customer, bool>> GetNameMaiorCincoCaracteres()
        {
            return x => x.Name.Count() > 5;
        }


         public static Expression<Func<Customer, bool>> GetNameMenorCincoCaracteres()
        {
            return x => x.Name.Count() <= 5;
        }
    }
}