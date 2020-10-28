using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;

namespace GroceryListService.Accessors
{
    public class ListAccessor : DbAccessor
    {
        public ListAccessor(SqlConnection connection) : base(connection) {}

        public Boolean ListExists(string listName, User user)
        {
            string query = "SELECT * FROM \"List\" as l JOIN \"User\" as u ON l.userId = u.userId WHERE l.\"name\" = @ListName AND u.\"email\" = @Email;";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);

                cmd.Parameters["@Email"].Value = user.Email;
                cmd.Parameters["@ListName"].Value = listName;
                cmd.Connection = GetConnection();
                try
                {
                    base.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        base.CloseConnection();
                        return true;
                    }
                    else
                    {
                        base.CloseConnection();
                        return false;
                    }

                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
