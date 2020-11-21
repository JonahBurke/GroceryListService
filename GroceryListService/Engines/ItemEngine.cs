using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace GroceryListService.Engines
{
    public class ItemEngine
    {
        public Item SelectItem(int id)
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

        public Boolean ItemExists(int id)
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

        public List<Item> SelectAllItems(List list)
        {
            if (list.Id > 0 && list.UserId > 0) // do a little bit of data "cleaning"
            { 
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return ia.SelectAllItems(list);
            }
            else
            {
                return null;
            }
        }

        public void InsertItem(Item item)
        {
            if (item.ListId > 0 && item.Name != null) // do a little bit of data "cleaning"
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                ia.InsertItem(item);
            }
        }

        public void RemoveItem(int id) // do a little bit of data "cleaning"
        {
            if (id > 0)
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                ia.RemoveItem(id);
            }
        }

        public void UpdateItem(Item item)
        {
            if (item.ListId > 0 && item.Id > 0 && item.Name != null) // do a little bit of data "cleaning"
            {
                ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
                ia.InsertItem(item);
            }
        }
    }
}
