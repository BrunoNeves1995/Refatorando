using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refatorando.Domain.Enums
{
    public enum EOrderStatus
    {
        //Aguardando Pagamento  
        WaitingPayment = 1,
        // Aguardando entrega
        WaitingDelivery = 2,
        Canceled = 3
    
    }
}