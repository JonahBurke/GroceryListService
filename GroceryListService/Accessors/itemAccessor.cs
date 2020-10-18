using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class ItemAccessor : DbAccessor
    {
        public ItemAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }

        public Boolean ItemExists(string itemName, List list)
        {
            string query = "SELECT * FROM \"Item\" as i JOIN \"List\" as l ON i.listId = l.listId " +
                "WHERE i.\"name\" = @ItemName AND l.\"name\" = @ListName AND l.\"userId\" = @UserID;";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@ItemName", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);

                cmd.Parameters["@ItemName"].Value = itemName;
                cmd.Parameters["@ListName"].Value = list.Name;
                cmd.Parameters["@UserID"].Value = list.UserId;
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
