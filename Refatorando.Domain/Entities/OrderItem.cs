using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;

namespace Refatorando.Domain.Entities
{   
    // ITEM DO PEDIDO
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(
                new Contract<OrderItem>()
                    .Requires()
                    .IsGreaterThan(quantity, 0, "OrderItem.Quantity", "A quantidade do pedido deve ser maior que zero")
                    .IsLowerThan(quantity, 0, "OrderItem.Quantity", "A quantidade do pedido não pode ser menor que zero")
            );

            Product = product;
            Price = Product != null ? product.Price : 0;
            Quantity = quantity;
        }

        public Product Product { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        // SUB TOTAL DO PRODUTO
        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}