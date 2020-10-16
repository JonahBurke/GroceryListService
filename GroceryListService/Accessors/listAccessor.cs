using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class ListAccessor : DbAccessor
    {
        public ListAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }

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
                    OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    CloseConnection();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
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
