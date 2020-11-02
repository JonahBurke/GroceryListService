using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class dbAccessor
    {
        string _connectionString;
        SqlConnection _connection;

        public dbAccessor(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public void openConnection()
        {
            _connection.Open();
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
