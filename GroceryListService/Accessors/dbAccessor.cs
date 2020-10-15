using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class DbAccessor
    {
        SqlConnection _connection;
        public DbAccessor(SqlConnection connection)
        {
            _connection = connection;
        }

        public void openConnection()
        {
            _connection.Open();
        }

        public void closeConnection()
        {
            _connection.Close();
        }
    }
}
