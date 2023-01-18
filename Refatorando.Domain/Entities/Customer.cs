using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;
using Refatorando.Domain.Repositories;

namespace Refatorando.Domain.Entities
{   
    // CLIENTE
    public class Customer : Entity
    {   

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;

            AddNotifications(
                new Contract<Order>()
                    .Requires()
                    .IsNotNullOrEmpty(name, "Customer.Name", "Nome é inválido")
                    .IsEmail(email, "Customer.Email", "E-mail é inválido")
            );
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}