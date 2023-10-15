using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Storages
{
    interface IBuyerStorage
    {
        Guid AddBuyer();

        bool DeleteBuyer(Guid buyerId);

        //List<Guid> GetAllBuyers();
    }
}
