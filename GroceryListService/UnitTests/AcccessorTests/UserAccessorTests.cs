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
    public class UserAccessorTests
    {
        [TestMethod]
        public void test_user_exists()
        {
            UserAccessor ua = new UserAccessor(new SqlConnection(DatabaseInfo.connectionString));
            string email = "email";
            string password = "password";
            Assert.IsTrue(ua.UserExists(email, password));
        }
    }
}
