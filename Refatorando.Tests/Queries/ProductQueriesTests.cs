using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refatorando.Domain.Entities;
using Refatorando.Domain.Queries;

namespace Refatorando.Tests.Queries
{   
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _products;

        public ProductQueriesTests()
        {   
            _products = new List<Product>();
            _products.Add(new Product("produto 1", 10, true));
            _products.Add(new Product("produto 2", 20, true));
            _products.Add(new Product("produto 3", 30, true));
            _products.Add(new Product("produto 4", 40, false));
            _products.Add(new Product("produto 5", 50, false));
        }
        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_uma_consulta_de_produtos_ativos_deve_retorna_3_produtos()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());

            Assert.AreEqual(3, result.Count());

        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_uma_consulta_de_produtos_inativos_deve_retorna_2_produtos()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());

            Assert.AreEqual(2, result.Count());
        }
    }
}