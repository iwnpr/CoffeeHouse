using System;
using System.Collections.Generic;
using CoffeeHouse.Domains;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse.Storages
{
    public class BuyerInMemoryStorage : IBuyerStorage
    {
        public BuyerInMemoryStorage()
        {
            _allBuyers = new List<Buyer>();
        }

        private List<Buyer> _allBuyers;

        public Guid AddBuyer()
        {
            var buyer = new Buyer();
            _allBuyers.Add(buyer);

            return buyer.Id;
        }

        public bool DeleteBuyer(Guid buyerId)
        {
            var isBuyer = _allBuyers.Any(b => b.Id == buyerId);

            if (isBuyer)
            {
                _allBuyers.RemoveAll(b => b.Id == buyerId);
            }

            return isBuyer;
        }

        //public List<Guid> GetAllBuyers()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
