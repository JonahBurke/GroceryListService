using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace GroceryListService.Engines
{
    public class ItemEngine
    {
        public static Item SelectItem(int id)
        {
            if (id > 0) // do a little bit of data "cleaning"
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.SelectItem(id);
            }
            else
            {
                return null;
            }
        }

        public static bool ItemExists(int id)
        {
            if (id > 0) // do a little bit of data "cleaning"
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.ItemExists(id);
            }
            else
            {
                return false;
            }
        }

        public static List<Item> SelectAllItems(List list)
        {
            if (list != null && list.Id > 0 && list.UserId > 0) // do a little bit of data "cleaning"
            { 
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.SelectAllItems(list);
            }
            else
            {
                return null;
            }
        }

        public static int InsertItem(Item item)
        {
            if (item != null && item.ListId > 0 && item.Name != null) // do a little bit of data "cleaning"
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.InsertItem(item);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }

        public static int RemoveItem(int id) // do a little bit of data "cleaning"
        {
            if (id > 0)
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.RemoveItem(id);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }

        public static int UpdateItem(Item item)
        {
            if (item != null && item.ListId > 0 && item.Id > 0 && item.Name != null) // do a little bit of data "cleaning"
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.InsertItem(item);
            }
            else
            {
                // Return a value the function won't return to differentiate error codes
                return -2;
            }
        }
    }
}
