﻿using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace GroceryListService.Accessors
{
    public class ItemAccessor : DbAccessor
    {
        public ItemAccessor(SqlConnection connection) : base(connection) { }

        public Item SelectItem(int id)
        {
            string query = "SELECT \"name\", \"quantity\", listId FROM \"Item\" WHERE itemId = @ItemID;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@ItemID", System.Data.SqlDbType.Int);

            cmd.Parameters["@ItemID"].Value = id;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                Item i = null;
                while (reader.Read())
                {
                    i = new Item
                    {
                        ListId = int.Parse(reader["listId"].ToString()),
                        Id = id,
                        Name = reader["name"].ToString(),
                        Quantity = reader.IsDBNull(1) ? -1 : int.Parse(reader["quantity"].ToString()) // -1 is the value for null table entries, since ints can't be null
                    };
                }
                reader.Close();
                CloseConnection();
                return i;

            }
            catch (SqlException)
            {
                return null;
            }
        }

        public bool ItemExists(int id)
        {
            return SelectItem(id) != null;
        }

        public List<Item> SelectAllItems(List list)
        {
            string query = "SELECT i.itemId, i.\"name\", i.\"quantity\" FROM \"Item\" as i JOIN \"List\" as l ON i.listId = l.listId " +
                "WHERE l.\"name\" = @ListName AND l.\"userId\" = @UserID;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            cmd.Parameters["@ListName"].Value = list.Name;
            cmd.Parameters["@UserID"].Value = list.UserId;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Item> itemList = null;
                if (reader.HasRows)
                {
                    itemList = new List<Item>();
                    while (reader.Read())
                    {
                        itemList.Add(
                            new Item
                            {
                                ListId = list.Id,
                                Id = int.Parse(reader["itemId"].ToString()),
                                Name = reader["name"].ToString(),
                                Quantity = reader.IsDBNull(2) ? -1 : int.Parse(reader["quantity"].ToString()) // -1 is the value for null table entries, since ints can't be null
                            });
                    }
                }

                reader.Close();
                CloseConnection();
                return itemList;

            }
            catch (SqlException)
            {
                return null;
            }
        }

        public int InsertItem(Item item)
        {
            string query = "INSERT INTO \"Item\" (\"name\", \"quantity\", listId) VALUES (@Name, @Quantity, @ListID);";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@ListID", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@ItemID", System.Data.SqlDbType.Int);
            if (item.Quantity > 0)
            {
                cmd.Parameters.Add("@Quantity", System.Data.SqlDbType.Int);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            }

            cmd.Parameters["@Name"].Value = item.Name;
            cmd.Parameters["@ListID"].Value = item.ListId;
            cmd.Parameters["@ItemID"].Value = item.Id;
            if (item.Quantity > 0)
            {
                cmd.Parameters["@Quantity"].Value = item.Quantity;
            }
            try
            {
                OpenConnection();
                int result = cmd.ExecuteNonQuery();
                CloseConnection();
                return result;
            }
            catch (SqlException)
            {
                // The database wasn't even accessed, so in case we want to do error messages
                // use a value that the result will never be.
                return -1;
            }
        }

        public int RemoveItem(int id)
        {
            string query = "DELETE FROM \"Item\" WHERE itemId = @ItemID;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@ItemID", System.Data.SqlDbType.Int);

            cmd.Parameters["@ItemID"].Value = id;
            try
            {
                OpenConnection();
                int result = cmd.ExecuteNonQuery();
                CloseConnection();
                return result;
            }
            catch (SqlException)
            {
                // The database wasn't even accessed, so in case we want to do error messages
                // use a value that the result will never be.
                return -1;
            }
        }

        public int UpdateItem(Item item)
        {
            string query = "UPDATE \"Item\" SET \"name\" = @Name, \"quantity\" = @Quantity, listId = @ListID WHERE itemId = @ItemID;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@ListID", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@ItemID", System.Data.SqlDbType.Int);
            if (item.Quantity > 0)
            {
                cmd.Parameters.Add("@Quantity", System.Data.SqlDbType.Int);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            }

            cmd.Parameters["@Name"].Value = item.Name;
            cmd.Parameters["@ListID"].Value = item.ListId;
            cmd.Parameters["@ItemID"].Value = item.Id;
            if (item.Quantity > 0)
            {
                cmd.Parameters["@Quantity"].Value = item.Quantity;
            }
            try
            {
                OpenConnection();
                int result = cmd.ExecuteNonQuery();
                CloseConnection();
                return result;
            }
            catch (SqlException)
            {
                // The database wasn't even accessed, so in case we want to do error messages
                // use a value that the result will never be.
                return -1;
            }
        }
    }
}