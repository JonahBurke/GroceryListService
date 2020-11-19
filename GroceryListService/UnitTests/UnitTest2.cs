
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
        public void ItemTest_getAllItem()
        {
            var controller = new ItemController(new MockItemRepo(), new NullLogger<ItemController>);
            
            var result = controller.getItem();
            var goodResult = result as ObjectiveResult;
            
            Assert.AreEqual(300, goodResult.statuscode);
        }

        [TestMethod]
        public void ListTest_getAllList()
        {
            var controller = new ListController(new MockListRepo(), new NullLogger<ListController>);
            
            var result = controller.getList(1);
            var goodResult = result as ObjectiveResult;
            
            Assert.AreEqual(result, actual);
        }
        
        /*[TestMethod]
        public void home_page_test()
        {
            HomePage obj = new HomePage();
            Assert.AreEqual(obj.Name, "GroceryListService Group-9");
        }*/
        
        [TestMethod]
        public void ListTest_tomatoes_updateListname()
        {
            string name = "tomatos";
            int expectedId = 3;
            
            List expectedList = new List{Id = 3, Listname = "tomatoes", quantity = 3, userID = 1};
            
            MockListRepo temp = new MockListRepo();
            
            List actualist = temp.updateListname(expectedId, newname);
            Assert. AreEqual(expectedList.Listname, actualist. Listname);
        }
    }
}
