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
    public class ItemAccessorTests
    {
        [TestMethod]
        public void test_item_exists()
        {
            // setup
            ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
            int id = 1;
            // Act and assert are heppening simultaneously here
            Assert.IsTrue(ia.ItemExists(id));
        }

        [TestMethod]
        public void test_select_item()
        {
            // setup
            ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
            int id = 1;
            string itemName = "Item 1";
            //Act
            Item i = ia.SelectItem(id);
            // Assert for each of the qualities of Item
            Assert.AreEqual(itemName, i.Name);
            Assert.AreEqual(1, i.Id);
            Assert.AreEqual(-1, i.Quantity);
        }

        [TestMethod]
        public void test_select_all_items()
        {
            // setup
            ItemAccessor ia = new ItemAccessor(new SqlConnection(DatabaseInfo.connectionString));
            List testList = new List
            {
                Name = "List 1",
                UserId = 1
            };
            //Act
            List<Item> itemList = ia.SelectAllItems(testList);
            // Assert that we should get 2 items from the database here
            Assert.AreEqual(2, itemList.Count());

        }
    }
}