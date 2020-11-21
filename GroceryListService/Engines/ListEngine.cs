using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace GroceryListService.Engines
{
    public class ListEngine
    {
        public static bool ListExists(string listName, User user)
        {
            if (user != null && listName != null && user.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.ListExists(listName, user);
            }
            else
            {
                return false;
            }
        }

        public static List SelectList(string listName, User user)
        {
            if (user != null && listName != null && user.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.SelectList(listName, user);
            }
            else
            {
                return null;
            }
        }

        public static List<List> SelectAllLists(User user)
        {
            if (user != null && user.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.SelectAllLists(user);
            }
            else
            {
                return null;
            }
        }

        public static int RemoveList(List list)
        {
            if (list != null && list.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.RemoveList(list);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }

        public static int UpdateList(List list)
        {
            if (list != null && list.Id > 0 && list.Name != null) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.UpdateList(list);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }

        public static int InsertList(List list)
        {
            if (list != null && list.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.InsertList(list);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }
    }
}
