using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse.Domains
{
    class Coffee
    {
        public Coffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            Name = name;
            Milk = milk;
            Volume = volume;
            Id = new Guid();
            Price = price;
            IsSugar = isSugar;
        }

        //public Coffee() {}

        public NamesOfCoffee Name { get; }

        public TypesOfMilk Milk { get; }

        public Volume Volume { get; set; }

        public Guid Id { get; set; }

        public float Price { get; set; }

        public bool IsSugar { get; set; }
    }
}
