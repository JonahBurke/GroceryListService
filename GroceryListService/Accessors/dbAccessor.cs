using Microsoft.Data.SqlClient;

namespace GroceryListService.Accessors
{
    public class DbAccessor
    {
        SqlConnection _connection;
        public DbAccessor(SqlConnection connection)
        {
            _connection = connection;
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
