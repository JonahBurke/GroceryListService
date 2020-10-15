using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class dbAccessor
    {
        SqlConnection _connection;
        public dbAccessor(SqlConnection connection)
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
