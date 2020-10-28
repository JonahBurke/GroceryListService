﻿using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace GroceryListService.Accessors
{
    public class ItemAccessor : DbAccessor
    {
        public ItemAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }

        /*public Item SelectItem(string itemName, List list)
        {
            string query = "SELECT i.itemId, i.\"name\", i.\"quantity\" FROM \"Item\" as i JOIN \"List\" as l ON i.listId = l.listId " +
                "WHERE i.\"name\" = @ItemName AND l.\"name\" = @ListName AND l.\"userId\" = @UserID;";
            using (SqlCommand cmd = new SqlCommand(query, base.GetConnection()))
            {
                cmd.Parameters.Add("@ItemName", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);

                cmd.Parameters["@ItemName"].Value = itemName;
                cmd.Parameters["@ListName"].Value = list.Name;
                cmd.Parameters["@UserID"].Value = list.UserId;
                try
                {
                    base.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Item i = null;
                    while (reader.Read())
                    {
                        i = new Item
                        {
                            ListId = list.Id,
                            Id = Int32.Parse(reader["itemId"].ToString()),
                            Name = reader["name"].ToString(),
                            Quantity = reader.IsDBNull(2)?-1: Int32.Parse(reader["quantity"].ToString()) // -1 is the value for null table entries, since ints can't be null
                        };
                    }
                    reader.Close();
                    base.CloseConnection();
                    return i;

                }
                catch (SqlException)
                {
                    return null;
                }
            }
        }

        public Boolean ItemExists(string itemName, List list)
        {
            return SelectItem(itemName, list) != null;
        }*/

        public Item SelectItem(int id)
        {
            string query = "SELECT \"name\", \"quantity\", listId FROM \"Item\" WHERE itemId = @ItemID;";
            using (SqlCommand cmd = new SqlCommand(query, base.GetConnection()))
            {
                cmd.Parameters.Add("@ItemID", System.Data.SqlDbType.Int);

                cmd.Parameters["@ItemID"].Value = id;
                try
                {
                    base.OpenConnection();
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
                    base.CloseConnection();
                    return i;

                }
                catch (SqlException)
                {
                    return null;
                }
            }
        }

        public Boolean ItemExists(int id)
        {
            return SelectItem(id) != null;
        }

        public List<Item> SelectAllItems(List list)
        {
            string query = "SELECT i.itemId, i.\"name\", i.\"quantity\" FROM \"Item\" as i JOIN \"List\" as l ON i.listId = l.listId " +
                "WHERE l.\"name\" = @ListName AND l.\"userId\" = @UserID;";
            using (SqlCommand cmd = new SqlCommand(query, base.GetConnection()))
            {
                cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                cmd.Parameters["@ListName"].Value = list.Name;
                cmd.Parameters["@UserID"].Value = list.UserId;
                try
                {
                    base.OpenConnection();
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
                    base.CloseConnection();
                    return itemList;

                }
                catch (SqlException)
                {
                    return null;
                }
            }
        }

        public void InsertItem(Item item)
        {
            // TODO
        }

        public void RemoveItem(int id)
        {
            // TODO
        }

        public void UpdateItem(Item item)
        {
            // TODO
        }
    }
}
