using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Storages
{
    public class PurchaseStorage : IPurchaseStorage
    {
        public PurchaseStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public Guid AddPurchase(Guid buyerId, Guid coffeeId)
        {
            var purchase = new Purchase(buyerId, coffeeId);
            var insertExpression = $"INSERT INTO Purchases (Id, BuyerId, CoffeeId) VALIES ('{purchase.PurchaseId}, {buyerId}, {coffeeId}')";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(insertExpression, connection);

                    command.ExecuteNonQuery();

                    return purchase.PurchaseId;
                }
                catch (Exception)
                {
                    return Guid.Empty;
                }
                
            }
            
        }
        
        public bool DeletePurchase(Guid purchaseId)
        {
            var deleteExpression = $"DELETE FROM Purchase WHERE Id = '{purchaseId}')";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(deleteExpression, connection);

                    command.ExecuteNonQuery();

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
    }
}
