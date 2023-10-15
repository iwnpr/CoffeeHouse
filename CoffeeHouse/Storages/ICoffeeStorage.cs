using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Storages
{
    public interface ICoffeeStorage
    {
        Guid AddCoffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar);

        bool DeleteCoffee(Guid buyerId);
    }
}
