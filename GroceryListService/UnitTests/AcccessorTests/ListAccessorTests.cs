using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class ListAccessorTests
    {
        [TestMethod]
        public void test_list_exists()
        {
            // Setup
            ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
            string listName = "List 2";
            User testUser = new User
            {
                Id = 1,
                Email = "email"
            };
            // Act and assert at once
            Assert.IsTrue(la.ListExists(listName, testUser));
        }

        [TestMethod]
        public void test_select_all_lists()
        {
            // setup
            ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
            User testUser = new User
            {
                Id = 1,
                Email = "email"
            };
            //Act
            List<List> listList = la.SelectAllLists(testUser);
            // Assert that we should get 2 items from the database here
            Assert.AreEqual(2, listList.Count());

        }
    }
}