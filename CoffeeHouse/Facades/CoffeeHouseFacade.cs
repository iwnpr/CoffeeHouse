using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Storages;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Facades
{
    public class CoffeeHouseFacade
    {
        public CoffeeHouseFacade(CoffeeInMemoryStorage coffeeStorage, BuyerInMemoryStorage buyerStorage, PurchaseInMemoryStorage purchaseStorage)
        {
            _coffeeStorage = coffeeStorage;
            _buyerStorage = buyerStorage;
            _purchaseStorage = purchaseStorage;

        }

        private CoffeeInMemoryStorage _coffeeStorage;
        private BuyerInMemoryStorage _buyerStorage;
        private PurchaseInMemoryStorage _purchaseStorage;
        

        public Guid AddBuyer()
        {
            return _buyerStorage.AddBuyer();
        }

        public Guid AddCoffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            return _coffeeStorage.AddCoffee(name, milk, volume, price, isSugar);
        }

        public Guid AddPurchase(Guid buyerId, Guid coffeeId)
        {
            return _purchaseStorage.AddPurchase(buyerId, coffeeId);
        }

        public bool DeleteBuyer(Guid buyerId)
        {
            return _buyerStorage.DeleteBuyer(buyerId);
        }
        
        public bool DeleteCoffee(Guid CoffeeId)
        {
            return _coffeeStorage.DeleteCoffee(CoffeeId);
        }
        
        public bool DeletePurchase(Guid PurchaseId)
        {
            return _purchaseStorage.DeletePurchase(PurchaseId);
        }


    }
}
