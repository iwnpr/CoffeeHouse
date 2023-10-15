using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Domains;
using Microsoft.Data.SqlClient;

namespace CoffeeHouse.Storages
{
    public class BuyerStorage : IBuyerStorage
    {
        public BuyerStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public Guid AddBuyer()
        {
            var buyer = new Buyer();
            var insetExpression = $"INSERT INTO Buyers (Id) VALUES ('{buyer.Id}')";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(insetExpression, connection);

                    command.ExecuteNonQuery();

                    return buyer.Id;


                }
                catch (Exception)
                {
                    return Guid.Empty;
                }
            }
        }

        public bool DeleteBuyer(Guid buyerId)
        {
            var deleteExpression = $"DELETE FROM Buyers WHERE Id = '{buyerId}')";

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

        //public List<Guid> GetAllBuyers()
        //{
        //    var allBuyers = new List<Guid>();
        //    var selectExeption = "SELECT * FROM Buyers";

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            var command = new SqlCommand(selectExeption, connection);
        //            var reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                var id = reader["BuyerId"];
        //                allBuyers.Add((Guid)id);
        //            }

        //            return allBuyers;
        //        }
        //        catch (Exception)
        //        {

        //            return allBuyers;
        //        }
        //    }
        //}

    }
}
