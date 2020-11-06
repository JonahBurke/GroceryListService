﻿using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;

namespace GroceryListService.Accessors
{
    public class ListAccessor : DbAccessor
    {
        public ListAccessor(SqlConnection connection) : base(connection) { }

        public Boolean ListExists(string listName, User user)
        {
            return SelectList(listName, user) != null;
        }

        public List SelectList(string listName, User user)
        {
            string query = "SELECT \"listId\" FROM \"List\" WHERE \"name\" = @ListName AND userId = @UserID;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);

            cmd.Parameters["@ListName"].Value = listName;
            cmd.Parameters["@UserID"].Value = user.Id;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                List l = null;
                while (reader.Read())
                {
                    l = new List
                    {
                        UserId = user.Id,
                        Id = int.Parse(reader["listID"].ToString()),
                        Name = listName
                    };
                }
                reader.Close();
                CloseConnection();
                return l;

            }
            catch (SqlException)
            {
                return null;
            }
        }

        public void RemoveList(List list)
        {
            // Pretty sure we need to do this first
            string itemDelete = "DELETE FROM \"Item\" WHERE listId = (SELECT \"listId\" FROM \"List\" WHERE \"name\" = @ListName AND userId = @UserID);";
            string listDelete = "DELETE FROM \"List\" WHERE \"name\" = @ListName AND userId = @UserID;";
            using SqlCommand cmd1 = new SqlCommand(itemDelete, GetConnection());
            using SqlCommand cmd2 = new SqlCommand(listDelete, GetConnection());
            cmd1.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
            cmd1.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            cmd2.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
            cmd2.Parameters.Add("@UserID", System.Data.SqlDbType.Int);

            cmd1.Parameters["@ListName"].Value = list.Name;
            cmd1.Parameters["@UserID"].Value = list.UserId;
            cmd2.Parameters["@ListName"].Value = list.Name;
            cmd2.Parameters["@UserID"].Value = list.UserId;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd1.ExecuteReader();
                reader = cmd2.ExecuteReader();
                CloseConnection();
                return;
            }
            catch (SqlException)
            {
                return;
            }
        }

        public void UpdateList(List list)
        {
            string query = "UPDATE \"List\" SET \"name\" = @Name, userId = @UserID WHERE listId = @ListID;";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@ListID", System.Data.SqlDbType.Int);

            cmd.Parameters["@Name"].Value = list.Name;
            cmd.Parameters["@UserID"].Value = list.UserId;
            cmd.Parameters["@ListID"].Value = list.Id;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                CloseConnection();
                return;
            }
            catch (SqlException)
            {
                return;
            }
        }

        public void InsertList(List list)
        {
            string query = "INSERT INTO \"List\"(\"name\", \"userId\") values (@ListName, @UserID);";
            using SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.Add("@ListName", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int);

            cmd.Parameters["@ListName"].Value = list.Name;
            cmd.Parameters["@UserID"].Value = list.UserId;
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                CloseConnection();
                return;
            }
            catch (SqlException)
            {
                return;
            }
        }
    }
}