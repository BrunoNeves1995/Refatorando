using Refatorando.Domain.Entities;
using Refatorando.Domain.Queries;

namespace Refatorando.Tests.Queries
{   
    [TestClass]
    public class CustomerQueriesTests 
    {
         IList<Customer> _customers;
        public CustomerQueriesTests()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer("fabio neves", "fabio@gmail.com"));
            _customers.Add(new Customer("carol neves", "carol@gmail.com"));
            _customers.Add(new Customer("bruno freitas", "bruno@gmail.com"));
            _customers.Add(new Customer("ana", "bruno@gmail.com"));
            _customers.Add(new Customer("fabi", "bruno@gmail.com"));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_uma_consulta_de_customer_com_nome_Maior_que_5_caracteres_deve_retorna_3_customer()
        {
            var result = _customers.AsQueryable().Where(CustomerQueries.GetNameMaiorCincoCaracteres());
            Assert.AreEqual(3, result.Count());

        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_uma_consulta_de_Customer_com_name_Menor_ou_igual_a_5_caracteres_deve_retorna_2_customer()
        {
            var result = _customers.AsQueryable().Where(CustomerQueries.GetNameMenorCincoCaracteres());
            Assert.AreEqual(2, result.Count());
        }
    }
}