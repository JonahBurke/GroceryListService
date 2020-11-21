using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryListService.Models;
using GroceryListService.Engines;
using System.Collections.Generic;
using System.Linq;

namespace GroceryListService.UnitTests.EngineTests
{
    [TestClass]
    public class ListEngineTests
    {
        [TestMethod]
        public void select_list_good_data()
        {
            // Setup
            List expectedList = new List
            {
                Id = 1,
                Name = "List 1",
                UserId = 1
            };
            User expectedUser = new User
            {
                Id = 1,
                Email = "email"
            };
            // Act
            List result = ListEngine.SelectList(expectedList.Name, expectedUser);
            // Assert
            Assert.IsNotNull(result); // Make sure the result isn't null before we access anything
            // We don't need to test ID because if one was found, it has the same ID
            Assert.AreEqual(expectedList.Name, result.Name);
            Assert.AreEqual(expectedList.UserId, result.UserId);
        }

        [TestMethod]
        public void select_list_bad_data()
        {
            // Setup
            string badName = "Not a list";
            User badUser = new User
            {
                Id = 0,
                Email = "Not an Email"
            };
            // Act
            List result = ListEngine.SelectList(badName, badUser);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void list_exists_good_data()
        {
            // Setup
            string expectedName = "List 1";
            User expectedUser = new User
            {
                Id = 1,
                Email = "email"
            };
            // Act
            bool result = ListEngine.ListExists(expectedName, expectedUser);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void list_exists_bad_data()
        {
            // Setup
            string expectedName = "List 1";
            User expectedUser = null;
            // Act
            bool result = ListEngine.ListExists(expectedName, expectedUser);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void select_all_lists_good_data()
        {
            // Setup
            User good = new User
            {
                Id = 1,
                Email = "email"
            };
            // Act
            List<List> result = ListEngine.SelectAllLists(good);
            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void select_all_lists_bad_data()
        {
            // Setup
            User bad = null;
            // Act
            List<List> result = ListEngine.SelectAllLists(bad);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void insert_list_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            List bad = new List
            {
                Id = -1,
                Name = "Not a List",
                UserId = 0
            };
            // Act
            int result = ListEngine.InsertList(bad);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }

        [TestMethod]
        public void update_list_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            List bad = new List
            {
                Id = -1,
                Name = "Not a List",
                UserId = 0
            };
            // Act
            int result = ListEngine.UpdateList(bad);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }

        [TestMethod]
        public void remove_list_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            List bad = new List
            {
                Id = -1,
                Name = "Not a List",
                UserId = 0
            };
            // Act
            int result = ListEngine.RemoveList(bad);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }
    }
}
