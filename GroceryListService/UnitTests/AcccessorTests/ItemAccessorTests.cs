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
    public class ItemAccessorTests
    {
        [TestMethod]
        public void test_item_exists()
        {
            ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
            string itemName = "Item 1";
            List testList = new List();
            testList.Name = "List 1";
            testList.UserId = 1;
            Assert.IsTrue(ia.ItemExists(itemName, testList));
        }
    }
}
