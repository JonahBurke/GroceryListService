using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryListService.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void passingTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void failingTest()
        {
            Assert.IsTrue(false);
        }
    }
}
