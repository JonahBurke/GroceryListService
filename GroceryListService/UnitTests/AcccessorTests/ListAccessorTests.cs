using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class ListAccessorTests
    {
        [TestMethod]
        public void test_list_exists()
        {
            ListAccessor la = new ListAccessor(new SqlConnection(DatabaseInfo.connectionString));
            string listName = "List 2";
            User testUser = new User();
            testUser.Email = "test";
            Assert.IsTrue(la.ListExists(listName, testUser));
        }
    }
}
