using _GroceryListService.Models;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class UserAccessor : DbAccessor
    {
        public UserAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }

        public Boolean UserExists(string email, string password)
        {
            string query = "SELECT * FROM \"User\" WHERE \"email\" = @Email AND \"password\" = @Password;";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 100);

                cmd.Parameters["@Email"].Value = email;
                cmd.Parameters["@Password"].Value = password;
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
