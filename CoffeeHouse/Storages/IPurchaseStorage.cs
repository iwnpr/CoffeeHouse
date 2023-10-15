using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse.Storages
{
    interface IPurchaseStorage
    {
        Guid AddPurchase(Guid buyerId, Guid coffeeId);

        bool DeletePurchase(Guid purchaseId);
    }
}
