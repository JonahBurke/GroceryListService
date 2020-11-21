using GroceryListService.Engines;
using GroceryListService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryListService.UnitTests.EngineTests
{
    [TestClass]
    public class UserEngineTests
    {
        [TestMethod]
        public void select_user_good_data()
        {
            // Setup
            User expectedUser = new User
            {
                Id = 1,
                Email = "email",
                Password = "password",
                Nickname = "nick"
            };
            // Act
            User result = UserEngine.SelectUser(expectedUser.Id);
            // Assert
            Assert.IsNotNull(result); // Make sure the result isn't null before we access anything
            // We don't need to test ID because if one was found, it has the same ID
            Assert.AreEqual(expectedUser.Email, result.Email);
            Assert.AreEqual(expectedUser.Password, result.Password);
            Assert.AreEqual(expectedUser.Nickname, result.Nickname);
        }

        [TestMethod]
        public void select_user_bad_data()
        {
            // Setup
            User badUser = new User
            {
                Id = 0,
                Email = "Not an Email"
            };
            // Act
            User result = UserEngine.SelectUser(badUser.Id);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void user_exists_good_data()
        {
            // Setup
            int goodID = 1;
            // Act
            bool result = UserEngine.UserExists(goodID);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void user_exists_bad_data()
        {
            // Setup
            int badID = -1;
            // Act
            bool result = UserEngine.UserExists(badID);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void insert_user_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            User badUser = new User
            {
                Email = null,
                Password = null,
                Nickname = null
            };
            // Act
            int result = UserEngine.InsertUser(badUser);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }

        [TestMethod]
        public void insert_user_good_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            User user = new User
            {
                Email = "test",
                Password = "test",
                Nickname = null
            };
            // Act
            int result = UserEngine.InsertUser(user);
            // Assert
            Assert.AreEqual(1, result); // -2 because the engine catches the bad data
        }

        [TestMethod]
        public void update_user_bad_data() // We're not going to test good data, because I don't want to mess with the database too much
        {
            // Setup
            User badUser = new User
            {
                Email = null,
                Password = null,
                Nickname = null
            };
            // Act
            int result = UserEngine.UpdateUser(badUser);
            // Assert
            Assert.AreEqual(-2, result); // -2 because the engine catches the bad data
        }
    }
}
