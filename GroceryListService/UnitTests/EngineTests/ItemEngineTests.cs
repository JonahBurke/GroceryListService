using GroceryListService.Engines;
using GroceryListService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GroceryListService.UnitTests.EngineTests
{
    [TestClass]
    public class ItemEngineTests
    {
        [TestMethod]
        public void select_item_good_data()
        {
            // Setup
            Item expected = new Item
            {
                Id = 1,
                Name = "Item 1",
                Quantity = -1, // -1 is the value associated with a null table entry for Quantity
                ListId = 1
            };
            // Act
            Item result = ItemEngine.SelectItem(expected.Id);
            // Assert
            Assert.IsNotNull(result); // Make sure the result isn't null before we access anything
            // We don't need to test ID because if one was found, it has the same ID
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Quantity, result.Quantity);
            Assert.AreEqual(expected.ListId, result.ListId);
        }

        [TestMethod]
        public void select_item_bad_data()
        {
            // Setup
            int badID = -1;
            // Act
            Item result = ItemEngine.SelectItem(badID);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void item_exists_good_data()
        {
            // Setup
            int goodID = 1;
            // Act
            bool result = ItemEngine.ItemExists(goodID);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void item_exists_bad_data()
        {
            // Setup
            int badID = -1;
            // Act
            bool result = ItemEngine.ItemExists(badID);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void select_all_items_good_data()
        {
            // Setup
            List good = new List
            {
                Id = 1,
                Name = "List 1",
                UserId = 1
            };
            // Act
            List<Item> result = ItemEngine.SelectAllItems(good);
            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void select_all_items_bad_data()
        {
            // Setup
            List bad = new List
            {
                Id = -1,
                Name = "Not a List",
                UserId = 0
            };
            // Act
            List<Item> result = ItemEngine.SelectAllItems(bad);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void insert_item_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            Item bad = new Item
            {
                Id = -1,
                Name = "Not an Item",
                ListId = 0,
                Quantity = -1
            };
            // Act
            int result = ItemEngine.InsertItem(bad);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }

        [TestMethod]
        public void update_item_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            Item bad = new Item
            {
                Id = -1,
                Name = "Not an Item",
                ListId = 0,
                Quantity = -1
            };
            // Act
            int result = ItemEngine.UpdateItem(bad);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }

        [TestMethod]
        public void remove_item_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            int badID = -1;
            // Act
            int result = ItemEngine.RemoveItem(badID);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }
    }
}
