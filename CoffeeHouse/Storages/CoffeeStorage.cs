using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CoffeeHouse.Domains;

namespace CoffeeHouse.Storages
{
    public class CoffeeStorage : ICoffeeStorage
    {
        public CoffeeStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public Guid AddCoffee(NamesOfCoffee name, TypesOfMilk milk, Volume volume, float price, bool isSugar)
        {
            var coffee = new Coffee(name, milk, volume, price, isSugar);
            var insetExpression = $"INSERT INTO Coffees (Id, Name, Milk, Volume, Price, IsSugar) " +
                $"VALUES ('{coffee.Id}', '{coffee.Name}', '{coffee.Milk}', '{coffee.Volume}, '{coffee.Price}', '{coffee.IsSugar}')";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(insetExpression, connection);

                    command.ExecuteNonQuery();

                    return coffee.Id;
                }
                catch (Exception)
                {
                    return Guid.Empty;
                }
            }
        }

        public bool DeleteCoffee(Guid coffeeId)
        {
            var deleteExpression = $"DELETE FROM Coffees WHERE Id = '{coffeeId}')";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(deleteExpression, connection);

                    var result = command.ExecuteNonQuery();

                    return result > 0;
                    
                }
                catch (Exception)
                {
                    return false;
                }

            }
            
        }
        
    }
}
