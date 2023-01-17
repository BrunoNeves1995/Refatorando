

using System.Linq;
using Flunt.Validations;
using Refatorando.Domain.Enums;

namespace Refatorando.Domain.Entities
{
    // PEDIDO
    public class Order : Entity
    {
        private IList<OrderItem> _items;
        public Order(Customer customer, decimal deliveryFee, Discount discount)
        {

            Customer = customer;
            Date = DateTime.Now;
            Number = Guid.Parse(Guid.NewGuid().ToString().Substring(0, 8));
            Status = EOrderStatus.WaitingPayment;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _items = new List<OrderItem>();

            AddNotifications(
                new Contract<Order>()
                    .Requires()
                    .IsNotNull(deliveryFee, "Order.DeliveryFee", "Taxa de entrega é inválido")
                    .IsGreaterThan(_items.Count(), 0, "Order.Items", "Pedido é invalido, nao existem item vinculado a este pedido")
            );

        }

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public Guid Number { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get { return _items.ToArray(); } }
        public decimal DeliveryFee { get; private set; }
        public Discount Discount { get; private set; }
        public EOrderStatus Status { get; private set; }

        // Adicionando item ao pedido
        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);
            // passando notificação do filho para o pai e com isso o pedido deixa de ser valido

            AddNotifications(item.Notifications);
            _items.Add(item);
        }

        // Calculando o total do pedido
        public decimal TotalOrder()
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                total += item.Total();
            }

            total += DeliveryFee;
            total -= Discount != null ? Discount.ValueCupom() : 0;

            return total;
        }

        // metodo de pagamento
        public void Pay(decimal value)
        {
            AddNotifications(
                new Contract<Order>()
                    .Requires()
                    .IsGreaterOrEqualsThan(value, TotalOrder(), "Order.Pay", "O valor de pagamento não pode ser menor que o valor total do pedido")
            );

            if (IsValid)
                this.Status = EOrderStatus.WaitingDelivery;
        }

        // Cancela o pedido
        public void Cancel()
        {
            if (this.Status == EOrderStatus.WaitingDelivery)
                AddNotification("Order.Cancel", "O Pedido não pode ser Cancelado, por que esta aguardando entrega");

            this.Status = EOrderStatus.WaitingDelivery;

        }
    }
}
