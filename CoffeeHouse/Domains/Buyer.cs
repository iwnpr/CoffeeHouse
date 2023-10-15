using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse.Domains
{
    class Buyer
    {
        public Buyer()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
