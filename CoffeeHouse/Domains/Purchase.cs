using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse.Domains
{
    class Purchase
    {
        public Purchase(Guid buyerId, Guid coffeeId)
        {
            buyerId = BuyerId;
            coffeeId = CoffeeId;
            PurchaseId = Guid.NewGuid();
        }

        public Guid PurchaseId { get; }

        public Guid BuyerId { get; }

        public Guid CoffeeId { get; }
    }
}
