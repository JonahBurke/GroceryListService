using GroceryListService.Accessors;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void db_connection_good_string_test()
        {
            // Feed the database connector the actual connection string for the database hosted on Azure
          /*  dbAccessor testAccessor = new dbAccessor(DatabaseInfo.connectionString);
            try
            {
                testAccessor.openConnection();
            }
            catch (SqlException e)
            {
                // This shouldn't happen, since the connection string is good
                // But just in case, it would be good to have the ability to fail.
                Assert.Fail();
            }

            // If we make it this far and haven't seen an exception, then we know that we can open a connection
            Assert.IsTrue(true);
            // Close the connection
            testAccessor.closeConnection(); */
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void db_connection_bad_string_test()
        {
            // We need the conection string to begin like a real connection string, otherwise we get an argument exception rather than an SQL exception
            DbAccessor testAccessor = new DbAccessor(new SqlConnection("Server = bad_input;"));
            // Open the bad connection, which will throw the SQL exception since it can't open the "server"
            testAccessor.OpenConnection();
            // The connection never actually gets opened, so no need to close the connection
        }

        /*[TestMethod]
        public void home_page_test()
        {
            HomePage obj = new HomePage();
            Assert.AreEqual(obj.Name, "GroceryListService Group-9");
        }*/
    }
}
