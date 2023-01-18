using Refatorando.Domain.Entities;
using Refatorando.Domain.Enums;

namespace Refatorando.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {

        private readonly Customer _customer = new Customer("Bruno", "nevesbruno814@gmail.com");
        private readonly Discount _discount = new Discount(DateTime.Now.AddDays(1), 10);
        private readonly Product _product = new Product("produto 1", 10);



        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_Valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {

            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(8, order.Number.Length);
        }



        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_valido_seu_status_deve_ser_aguardando_entrega()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(100);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }



        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_valido_se_cancelado_antes_do_pagamento_deve_retorna_status_cancelado()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Cancel();

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(EOrderStatus.Canceled, order.Status);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_valido_com_pagamento_efetuado_se_depois_for_cancelado_deve_retorna_um_erro()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(100);
            order.Cancel();

            Assert.IsFalse(order.IsValid);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_do_pedido_sem_o_produto_deve_retorna_um_pedido_invalido_e_nao_adicionado_os_produto_no_itens_do_pedido()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(null!, 10);
            order.AddItem(orderItem);
            order.Pay(100);

            Assert.IsFalse(order.IsValid);
            Assert.AreEqual(0, order.Items.Count());
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_do_pedido_com_quantidade_zero_o_mesmo_nao_deve_ser_adicionado_ao_pedido()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product!, 0);
            order.AddItem(orderItem);
            order.Pay(100);

            Assert.IsFalse(order.IsValid);
            Assert.AreEqual(0, order.Items.Count());
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_100()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product!, 10);
            order.AddItem(orderItem);
            order.Pay(100);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(100, order.TotalOrder());
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_menor_que_o_total_do_pedido_deve_retorna_um_pedido_invalido()
        {
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product!, 10);
            order.AddItem(orderItem);
            order.Pay(90);

            Assert.IsFalse(order.IsValid);

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_110()
        {   
            var discount = new Discount(DateTime.Now.AddDays(-1), 10);
            var order = new Order(_customer, 10, discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(110);

            Assert.IsFalse(order.IsValid);
            Assert.AreEqual(110, order.TotalOrder());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_110()
        {   
            var discount = new Discount(DateTime.Now.AddDays(1), -1);
            var order = new Order(_customer, 10, discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(110);

            Assert.IsFalse(order.IsValid);
            Assert.AreEqual(110, order.TotalOrder());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_10_o_valor_do_pedido_deve_ser_90()
        {   
            
            var order = new Order(_customer, 0, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(90);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(90, order.TotalOrder());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_10_e_a_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_100()
        {   
            
            var order = new Order(_customer, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(100);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(100, order.TotalOrder());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_110()
        {   
            var discount = new Discount(DateTime.Now.AddDays(1), 0);
            var order = new Order(_customer, 10, discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(110);

            Assert.IsTrue(order.IsValid);
            Assert.AreEqual(110, order.TotalOrder());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_sem_cliente_deve_retorna_um_peido_invalido()
        {
            var customer = new Customer("", "nevesbruno814@gmail.com");
            var order = new Order(null!, 10, _discount);
            var orderItem = new OrderItem(_product, 10);
            order.AddItem(orderItem);
            order.Pay(100);

            Assert.IsFalse(order.IsValid);
            
        }
    }
}