using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refatorando.Domain.Entities;
using Refatorando.Domain.Repositories;

namespace Refatorando.Tests.Repositories
{
    public class FakeOrderRepository : IOrderREpository
    {
        public void Save(Order order)
        {
            
        }
    }
}