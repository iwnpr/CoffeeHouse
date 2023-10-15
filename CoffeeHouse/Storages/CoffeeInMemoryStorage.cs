using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Storages
{
    public class CoffeeInMemoryStorage : ICoffeeStorage
    {
        public CoffeeInMemoryStorage()
        {
            _allCoffees = new List<Coffee>();
        }
        
        private List<Coffee> _allCoffees;

        public Guid AddCoffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            var coffee = new Coffee(name, milk, volume, price, isSugar);
            _allCoffees.Add(coffee);

            return coffee.Id;
        }

        public bool DeleteCoffee(Guid coffeeId)
        {
            var isCoffee = _allCoffees.Any(c => c.Id == coffeeId);

            if (isCoffee)
            {
                _allCoffees.RemoveAll(c => c.Id == coffeeId);
            }

            return isCoffee;
        }
    }
}
