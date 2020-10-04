using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _GroceryListService.Data;
using GroceryListService.Accessors;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void db_connection_test()
        {
            dbAccessor testAccessor = new dbAccessor();
            try
            {
                testAccessor.openConnection();
            }
            catch (SqlException e)
            {
                Assert.Fail();
            }

            // If we make it this far and haven't seen an exception, then we know that we can open a connection
            Assert.IsTrue(true);
            testAccessor.closeConnection();
        }
    }
}
