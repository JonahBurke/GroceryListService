using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;

namespace GroceryListService.Engines
{
    public class UserEngine
    {
        public Boolean UserExists(int id)
        {
            if (id > 0) // do a little bit of data "cleaning"
            {
                UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ua.UserExists(id);
            }
            else
            {
                return false;
            }
        }

        public User SelectUser(int id)
        {
            if (id > 0) // do a little bit of data "cleaning"
            {
                UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ua.SelectUser(id);
            }
            else
            {
                return null;
            }
        }

        public void InsertUser(string email, string password, string nickname)
        {
            if(email != null && password != null) // do a little bit of data "cleaning"
            {
                UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
                ua.InsertUser(email, password, nickname);
            }
        }

        public void UpdateUser(User user)
        {
            if (user.Id > 0 && user.Email != null && user.Password != null) // do a little bit of data "cleaning"
            {
                UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
                ua.UpdateUser(user);
            }
        }
    }
}
