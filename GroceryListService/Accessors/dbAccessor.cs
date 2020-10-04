using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class dbAccessor
    {
        string connectionString = "Server = tcp:test-361.database.windows.net,1433; Initial Catalog = Test; Persist Security Info = False; User ID = jburke; Password = CS-Rocks; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        SqlConnection _connection;

        public dbAccessor()
        {
            _connection = new SqlConnection(connectionString);
        }

        public void openConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Failed to open Connection");
            }
        }

        public void closeConnection()
        {
            _connection.Close();
        }

        public SqlConnection getConnection()
        {
            return _connection;
        }
    }
}
