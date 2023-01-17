using Flunt.Validations;

namespace Refatorando.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price)
        {

            Name = name;
            Price = price;
            Active = true;

            AddNotifications(
               new Contract<Product>()
                   .Requires()
                   .IsNotNull(name, "Product.Name", "Nome do produto é inválido")
                   .IsGreaterThan(price, 0,"Product.Price", "Preço do produto deve ser maior que zero")
                   .IsLowerThan(price, 0,"Product.Price", "Preço do produto não pode ser menor que zero")
                //    .IsTrue(active, "Product.Active", "Produto não esta ativo")
           );
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}