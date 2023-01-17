using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace Refatorando.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount( DateTime expireDate, decimal value)
        {
            Value = value;
            ExpireDate = expireDate;

            AddNotifications(
                new Contract<Discount>()
                    .Requires()
                    .IsNotNull(value, "Discount.Value", "Desconto é invalido")
                    .IsGreaterOrEqualsThan(expireDate, DateTime.Now, "Discount.ExpireDate", "Data de expiração de ver maior ou igual a data de hoje")
            );

        }

        public decimal Value { get; private set; }
        public DateTime ExpireDate { get; private set; }

        // Compara se a data esta no passado

        public decimal ValueCupom()
        {
            if (IsValid)
                return Value;
            else
                return 0;
        }
    }
}