using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;

namespace GroceryListService.Engines
{
    public class UserEngine
    {
        public static bool UserExists(int id)
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

        public static User SelectUser(int id)
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

        public static int InsertUser(User user)
        {
            if(user != null && user.Email != null && user.Password != null) // do a little bit of data "cleaning"
            {
                UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ua.InsertUser(user);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }

        public static int  UpdateUser(User user)
        {
            if (user != null && user.Id > 0 && user.Email != null && user.Password != null) // do a little bit of data "cleaning"
            {
                UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ua.UpdateUser(user);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }
    }
}
