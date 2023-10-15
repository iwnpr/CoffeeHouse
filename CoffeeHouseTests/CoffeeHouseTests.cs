using System;
using CoffeeHouse.Storages;
using CoffeeHouse.Facades;
using CoffeeHouse.Domains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeHouseTests
{
    [TestClass]
    public class CoffeeHouseTests
    {
        private BuyerInMemoryStorage _buyerInMemoryStorage;
        private CoffeeInMemoryStorage _coffeeInMemoryStorage;
        private PurchaseInMemoryStorage _purchaseInMemoryStorage;
        private CoffeeHouseFacade _coffeeHouseFacade;

        [TestInitialize]
        public void CoffeeHouseTestsInitialize()
        {
            _buyerInMemoryStorage = new BuyerInMemoryStorage();
            _coffeeInMemoryStorage = new CoffeeInMemoryStorage();
            _purchaseInMemoryStorage = new PurchaseInMemoryStorage();
            _coffeeHouseFacade = new CoffeeHouseFacade(_coffeeInMemoryStorage, _buyerInMemoryStorage, _purchaseInMemoryStorage);
        }

        [TestMethod]
        public void TryAddBuyer()
        {
            //act
            var facade = _coffeeHouseFacade.AddBuyer();
            var storage = _buyerInMemoryStorage.AddBuyer();

            //asert

            Assert.AreEqual(facade, storage);
            
        }

        [TestMethod]
        public void TryDeleteBuyer()
        {
            //act
            var guid1 = _buyerInMemoryStorage.AddBuyer();
            var storage = _buyerInMemoryStorage.DeleteBuyer(guid1);

            var guid2 = _coffeeHouseFacade.AddBuyer();
            var facade = _coffeeHouseFacade.DeleteBuyer(guid2);

            //asert
            Assert.AreEqual(facade, storage);
        }

        [DataTestMethod]
        [DataRow(NamesOfCoffee.Cappuccino, TypesOfMilk.Alternative, Volume.Medium, 150, true)]
        [DataRow(NamesOfCoffee.Americano, TypesOfMilk.Nope, Volume.Small, 130, false)]
        public void TryAddCoffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            var facade = _coffeeHouseFacade.AddCoffee(name, milk, volume, price, isSugar);
            var storage = _coffeeInMemoryStorage.AddCoffee(name, milk, volume, price, isSugar);

            Assert.AreEqual(facade, storage);
        }
        
        [DataTestMethod]
        [DataRow(NamesOfCoffee.Cappuccino, TypesOfMilk.Alternative, Volume.Medium, 150, true)]
        [DataRow(NamesOfCoffee.Americano, TypesOfMilk.Nope, Volume.Small, 130, false)]
        public void TryDeleteCoffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            var guid1 = _coffeeHouseFacade.AddCoffee(name, milk, volume, price, isSugar);
            var facade = _coffeeHouseFacade.DeleteCoffee(guid1);
            
            var guid2 = _coffeeInMemoryStorage.AddCoffee(name, milk, volume, price, isSugar);
            var storage = _coffeeInMemoryStorage.DeleteCoffee(guid2);
            
            Assert.AreEqual(facade, storage);
        }
        
        [DataTestMethod]
        [DataRow(NamesOfCoffee.Cappuccino, TypesOfMilk.Alternative, Volume.Medium, 150, true)]
        [DataRow(NamesOfCoffee.Americano, TypesOfMilk.Nope, Volume.Small, 130, false)]
        public void TryDeletePurchase(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            //arrange
            var buyerId = _coffeeHouseFacade.AddBuyer();
            var coffeeId = _coffeeHouseFacade.AddCoffee(name, milk, volume, price, isSugar);
            
            //act
            var purchaseId1 = _coffeeHouseFacade.AddPurchase(buyerId, coffeeId);
            var facade = _coffeeHouseFacade.DeletePurchase(purchaseId1);

            var purchaseId2 = _coffeeHouseFacade.AddPurchase(buyerId, coffeeId);
            var storage = _purchaseInMemoryStorage.DeletePurchase(purchaseId2);

            //assert
            Assert.AreEqual(facade, storage);

        }








    }
}
