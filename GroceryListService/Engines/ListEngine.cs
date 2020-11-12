using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace GroceryListService.Engines
{
    public class ListEngine
    {
        public Boolean ListExists(string listName, User user)
        {
            if (listName != null && user.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.ListExists(listName, user);
            }
            else
            {
                return false;
            }
        }

        public List SelectList(string listName, User user)
        {
            if (listName != null && user.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.SelectList(listName, user);
            }
            else
            {
                return null;
            }
        }

        public List<List> SelectAllLists(User user)
        {
            if (user.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                return la.SelectAllLists(user);
            }
            else
            {
                return null;
            }
        }

        public void RemoveList(List list)
        {
            if (list.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                la.RemoveList(list);
            }
        }

        public void UpdateList(List list)
        {
            if (list.Id > 0 && list.Name != null) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                la.UpdateList(list);
            }
        }

        public void InsertList(List list)
        {
            if (list.Id > 0) // do a little bit of data "cleaning"
            {
                ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
                la.InsertList(list);
            }
        }
    }
}
