using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Storages;


namespace CoffeeHouseConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Server = localhost; Database = CoffeeHouseDb; Trusted_Connection = True; TrustServerCertificate = Yes";

            var buyerStorage = new BuyerStorage(connectionString);
            var cooffeeStorage = new CoffeeStorage(connectionString);
            var purchaseStorage = new PurchaseStorage(connectionString);




        }
    }
}
