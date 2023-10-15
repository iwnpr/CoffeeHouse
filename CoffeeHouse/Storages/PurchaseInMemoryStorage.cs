using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Storages
{
    public class PurchaseInMemoryStorage : IPurchaseStorage
    {
        public PurchaseInMemoryStorage()
        {
            _allPurchase = new List<Purchase>();
        }

        private List<Purchase> _allPurchase;

        public Guid AddPurchase(Guid buyerId, Guid coffeeId)
        {
            var purchase = new Purchase(buyerId, coffeeId);
            _allPurchase.Add(purchase);

            return purchase.PurchaseId;
        }

        public bool DeletePurchase(Guid purchaseId)
        {
            var isPurchase = _allPurchase.Any(p => p.PurchaseId == purchaseId);

            if (isPurchase)
            {
                _allPurchase.RemoveAll(p => p.PurchaseId == purchaseId);
            }

            return isPurchase;
        }
    }
}
