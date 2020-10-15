using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _GroceryListService.Data;
using GroceryListService.Accessors;
using GroceryListService.Data;
using GroceryListService.Engines;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class ItemEngineTester
    {
        [TestMethod]
        public void test_getID()
        {
            // because id is an int, it can never be null, so we don't need extra checks for that
            int id = 1;
            string name = "test";
            int quantity = 0;

            ItemEngine ie = new ItemEngine(id, name, quantity);

            Assert.AreEqual(id, ie.getID());
        }

        [TestMethod]
        public void test_getID_bad_comparison()
        {
            int id = 1;
            string name = "test";
            int quantity = 0;

            ItemEngine ie = new ItemEngine(2, name, quantity);

            Assert.AreNotEqual(id, ie.getID());
        }

        [TestMethod]
        public void test_getQuantity()
        {
            // because quantity is an int, it can never be null, so we don't need extra checks for that
            int id = 1;
            string name = "test";
            int quantity = 0;

            ItemEngine ie = new ItemEngine(id, name, quantity);

            Assert.AreEqual(quantity, ie.getQuantity());
        }

        [TestMethod]
        public void test_getQuantity_bad_comparison()
        {
            int id = 1;
            string name = "test";
            int quantity = 0;

            ItemEngine ie = new ItemEngine(id, name, 1);

            Assert.AreNotEqual(quantity, ie.getQuantity());
        }

        [TestMethod]
        public void test_getName_not_null()
        {
            // If name is not null, then retrieving it should be the same for any name
            int id = 1;
            string name = "test";
            int quantity = 0;

            ItemEngine ie = new ItemEngine(id, name, quantity);

            Assert.AreEqual(name, ie.getName());
        }

        [TestMethod]
        public void test_getName_bad_comparison()
        {
            int id = 1;
            string name = "test";
            int quantity = 0;

            ItemEngine ie = new ItemEngine(id, "other", quantity);

            Assert.AreNotEqual(name, ie.getName());
        }

        [TestMethod]
        public void test_getName_null()
        {
            // In theory, this shouldn't change a whole lot, but we should check for it anyways
            int id = 1;
            int quantity = 0;

            ItemEngine ie = new ItemEngine(id, null, quantity);

            Assert.IsNull(ie.getName());
        }
    }
}
