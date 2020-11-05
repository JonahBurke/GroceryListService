using GroceryListService.Accessors;
using GroceryListService.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class UserAccessorTests
    {
        [TestMethod]
        public void test_user_exists()
        {
            UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
            Assert.IsTrue(ua.UserExists(1));
        }
    }
}