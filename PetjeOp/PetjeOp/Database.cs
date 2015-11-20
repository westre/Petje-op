using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp
{
    class Database
    {
        SqlConnection connection;

        public string LoadConfig()
        {
            string connectionString = "user id=jonaham;password=12;server=176.31.253.42,119;database=kbs2;";

            return connectionString;
        }

        public bool Connect()
        {            
            SqlConnection connection = new SqlConnection(LoadConfig());
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [user]";
            cmd.Connection = connection;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["user"].ToString());
                }
            }
            return true;
        }
    }
}
