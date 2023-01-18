using Flunt.Validations;

namespace Refatorando.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price, bool active)
        {

            Name = name;
            Price = price;
            Active = active;

            AddNotifications(
               new Contract<Product>()
                   .Requires()
                    .IsNotNull(active, "Product.Active", "Ativo do produto é inválido")
                   .IsNotNull(name, "Product.Name", "Nome do produto é inválido")
                   .IsGreaterThan(price, 0,"Product.Price", "Preço do produto deve ser maior que zero")
                   .IsLowerThan(0, price, "Product.Price", "Preço do produto não pode ser menor que zero")
                //    .IsTrue(active, "Product.Active", "Produto não esta ativo")
           );
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}